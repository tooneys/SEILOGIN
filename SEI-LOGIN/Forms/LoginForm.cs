using SEI_LOGIN.Common;
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

        private static async Task<bool> Fn_isProcessing(string processName)
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

        private static async Task Fn_killingProcess(string processName)
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
            string? CorpCode = cmbCompany.SelectedValue.ToString();
            SystemFileUpload fileUpload = new SystemFileUpload(CorpCode);
            fileUpload.ShowDialog();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string? companyValue = cmbCompany.SelectedValue.ToString();
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

            //Message Visible
            MessageVisible();

            if (await Login(companyValue!, userId, userPwd))
            {
                //Process Finished
                MessageShowing("Exits the existing launcher.");
                foreach (string fileName in fileNames)
                {
                    if (await Fn_isProcessing(fileName))
                    {
                        await Fn_killingProcess(fileName);
                    }
                }

                MessageShowing("Checking for update files.");

                //UploadFile Download
                int DownloadCount = await UploadFileCount();

                //File Downloading...
                await DownloadUpdateFile(companyValue!);


                if (DownloadCount > 0)
                    MessageShowing($" {DownloadCount} Download the files.");

                //File Transfer
                //Upload 폴더에 있는 파일은 전부 옮겨가기
                var sourceDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath, "Upload"));
                var destDirectory = new DirectoryInfo(Application.StartupPath);
                CopyDirectories(sourceDirectory, destDirectory);

                //File Transfer Complete
                MessageShowing("The update is complete.");

                //Upload Folder Delete
                Directory.Delete(Path.Combine(Application.StartupPath, "Upload"), true);

                //SEIERP.exe Execute
                Process.Start(new ProcessStartInfo
                {
                    FileName = Application.StartupPath + "\\SEIERP.EXE",
                    Arguments = ""
                });

                Application.Exit();
            }
            else
            {
                MessageShowing("Login failed... Retrying.");
            }
        }

        private static async Task<bool> Login(string Company, string Id, string Pwd)
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

        private void SettingsVisible() => SettingPanel.Visible = !SettingPanel.Visible;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetConfigIni();
            SettingsVisible();
        }

        private void MessageVisible() => msg.Visible = !msg.Visible;

        private void MessageShowing(string Message) => msg.Text = Message;

        private async Task<int> UploadFileCount()
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

        private async Task DownloadUpdateFile(string CorpCode)
        {
            string position = "Upload";

            byte[] bytes = null;
            DateTime fileDate;
            string dirName = string.Empty;
            string fileName = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Config.DBConnectString))
                using (SqlCommand cmd = new SqlCommand("SP_SYS_DOWNLOAD_UPDATEFILES_S", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@CD_CORP", CorpCode);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fileName = reader["NM_FILE"].ToString();
                        fileDate = DateTime.Parse(reader["DT_FILE"].ToString());
                        bytes = (byte[])reader["IM_FILEDATA"];

                        string downFolder = reader["NM_DOWNFOLDER"].ToString();
                        dirName = Path.Combine(Application.StartupPath, position, downFolder == "EXECUTE" ? "" : downFolder);

                        DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                        if (!dirInfo.Exists)
                            dirInfo.Create();

                        File.WriteAllBytes(Path.Combine(dirName, fileName), bytes);

                        FileInfo fileInfo = new FileInfo(Path.Combine(dirName, fileName));
                        fileInfo.CreationTime = fileInfo.LastAccessTime = fileInfo.LastWriteTime = fileDate;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageShowing($"[Downloading UpdateFile] :  + {ex.Message}");
            }
        }

        private void CopyDirectories(DirectoryInfo sourceDirectory, DirectoryInfo destDirectory)
        {
            MessageShowing("파일 복사 중 입니다.");

            foreach (FileInfo file in sourceDirectory.GetFiles())
            {
                file.CopyTo(Path.Combine(destDirectory.FullName, file.Name), true);
            }

            foreach (DirectoryInfo subDirectory in sourceDirectory.GetDirectories())
            {
                DirectoryInfo destSubDirectory = destDirectory.CreateSubdirectory(subDirectory.Name);
                CopyDirectories(subDirectory, destSubDirectory);
            }
        }
    }
}
