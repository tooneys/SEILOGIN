﻿using SEI_LOGIN.Common;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEI_LOGIN.Forms
{
    public partial class LoginForm : Form
    {
        private string[] fileNames = { "SEIERP" };
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
            Settings();

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

            void Settings()
            {
                //Visible Check
                SettingPanel.Visible = false;
                msg.Visible = false;

                //Components Check
                txtID.Text = Properties.Settings.Default.IDSave;
                txtID.Focus();
                SaveOption.Checked = Properties.Settings.Default.SaveOption;

                if (txtID.Text.Length > 0) { txtPassword.Focus(); }
            }
        }

        private void SetConfigIni()
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
                    process.Kill();
                    process.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static bool Fn_fileExist()
        {

            DirectoryInfo DirPath = new System.IO.DirectoryInfo(Application.StartupPath);
            FileInfo[] files = DirPath.GetFiles("*.exe");

            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_CHK_S", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string UpFileName = reader["NM_FILE"].ToString();
                    DateTime UpFileDate = DateTime.Parse(reader["DT_FILE"].ToString());
                    string UpDownFolder = reader["NM_DOWNFOLDER"].ToString();

                    //실행파일 경우만
                    if (UpDownFolder == "EXECUTE")
                    {
                        foreach (FileInfo file in files)
                        {
                            if (file.FullName == UpFileName && DateTime.Compare(file.LastWriteTime, UpFileDate) > 0)
                            {
                                MBox.ShowMessage("Continue");
                            }
                        }
                    }
                }
            }

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
            string CorpCode = cmbCompany.SelectedValue.ToString();
            SystemFileUpload fileUpload = new SystemFileUpload(CorpCode);
            fileUpload.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string companyValue = cmbCompany.SelectedValue.ToString();
            string userId = txtID.Text.ToString();
            string userPwd = txtPassword.Text.ToString();

            if (txtID.Text.Equals(""))
            {
                MBox.ShowErrorMessage("사용자ID를 입력하세요.");
                txtID.Focus();
                return;
            }
            else if (txtPassword.Text.Equals(""))
            {
                MBox.ShowErrorMessage("사용자PWD를 입력하세요.");
                txtPassword.Focus();
                return;
            }
            else
            {
                if (SaveOption.Checked)
                {
                    Properties.Settings.Default.SaveOption = SaveOption.Checked;
                    Properties.Settings.Default.IDSave = txtID.Text;
                    Properties.Settings.Default.Save();
                }
            }

            if (Login(companyValue, userId, userPwd))
            {
                MessageVisible();
                //Process Finished
                MessageShowing("기존 실행프로그램을 종료합니다.");
                foreach (string fileName in fileNames)
                {
                    if (Fn_isProcessing(fileName))
                    {
                        Fn_killingProcess(fileName);
                    }
                }
                
                MessageShowing("업데이트 파일이 있는지 확인중입니다.");
                
                //UploadFile Download
                int DownloadCount = UploadFileCount();
                MessageShowing($" {DownloadCount}개 파일 다운로드 합니다.");


                MessageShowing("업데이트가 완료되었습니다.");
                Application.Exit();
            }
            else
            {
                MBox.ShowErrorMessage("Login Failed");
            }
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

            if (Config.SetConfigIni(DBAddress, DBPort, Database, UID, PWD)) { SettingsVisible(); }
        }

        private void SettingsVisible()
        {
            SettingPanel.Visible = !SettingPanel.Visible;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetConfigIni();
            SettingsVisible();
        }

        private void MessageVisible()
        {
            msg.Visible = !msg.Visible;
        }

        private void MessageShowing(string Message)
        {
            msg.Text = Message;
        }

        private int UploadFileCount()
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_CHK_S", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                }
            }
            return count;
        }
    }
}
