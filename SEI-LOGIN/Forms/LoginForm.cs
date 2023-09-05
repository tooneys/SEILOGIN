using SEI_LOGIN.Common;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEI_LOGIN.Forms
{
    public partial class LoginForm : Form
    {
        private BindingList<object> companyList = new BindingList<object>();

        public LoginForm()
        {
            InitializeComponent();

            Config.GetConfigIni();

            InitForm();
        }

        private void InitForm()
        {
            SetConfigIni();
            CompanyInit();
            
            SettingPanel.Visible = false;
            txtID.Text = "SUPER";
            txtPassword.Text = "GIANT";

            void CompanyInit()
            {
                using (SqlConnection con = new SqlConnection(Config.DBConnectString))
                using (SqlCommand cmd = new SqlCommand("SP_COMN_COMPANY_CMB", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        companyList.Add(new { Code = reader["CD_CODE"], Name = reader["NM_CODE"] });
                    }
                }

                cmbCompany.DataSource = companyList;
                cmbCompany.DisplayMember = "Name";
                cmbCompany.ValueMember = "Code";
                cmbCompany.SelectedIndex = 0;
            }

            void SetConfigIni()
            {
                try
                {
                    txtDBAddress.Text = Config.DBAddress;
                    txtPort.Text = Config.DBPort;
                    txtUID.Text = Config.DBUserID;
                    txtDBPassword.Text = Config.DBUserPwd;
                    txtDatabase.Text = Config.DBDatabase;
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath;
            const string fileName = "SEIERP";

            //파일실행유무 체크
            if (Fn_isProcessing(fileName))
            {
                //Code Finding SEIERP
                DialogResult result = MessageBox.Show("실행중인 프로그램이 있습니다. 종료하고 진행하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Code Killing SEIERP
                    Fn_killingProcess(fileName);
                }
            }

            //파일유무 체크
            //Code DBFile & LocalFile Compare
            if (Fn_fileExist(filePath))
            {
                //Code
            }
        }

        private static bool Fn_isProcessing(string processName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void Fn_killingProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                try
                {
                    //저장여부 물어보고 닫기
                    process.CloseMainWindow();
                    //강제종료
                    //process.Kill();
                    process.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static bool Fn_fileExist(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsVisible();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            SystemFileUpload fileUpload = new SystemFileUpload();
            fileUpload.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string companyValue = cmbCompany.SelectedValue.ToString();
            string userId = txtID.Text.ToString();
            string userPwd = txtPassword.Text.ToString();

            if (Login(companyValue, userId, userPwd))
                MessageBox.Show("Login Successed");
            else
                MessageBox.Show("Login Failed");
        }

        private static bool Login(string Company, string Id, string Pwd)
        {
            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            using (SqlCommand cmd = new SqlCommand("SP_SYS_LOGIN_CHK_S", con))
            {
                cmd.Parameters.AddWithValue("@CD_CORP", Company);
                cmd.Parameters.AddWithValue("@CD_EMP", Id);
                cmd.Parameters.AddWithValue("@NO_PWD", Pwd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string DBAddress = txtDBAddress.Text;
            string DBPort = txtPort.Text;
            string Database = txtDatabase.Text;
            string UID = txtUID.Text;
            string PWD = txtDBPassword.Text;

            Config.SetConfigIni(DBAddress, DBPort, Database, UID, PWD);

            SettingsVisible();
        }

        private void SettingsVisible()
        {
            SettingPanel.Visible = !SettingPanel.Visible;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SettingsVisible();
        }
    }
}
