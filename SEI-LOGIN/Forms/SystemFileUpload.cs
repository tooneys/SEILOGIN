using SEI_LOGIN.Common;
using System.Data;
using System.Data.SqlClient;

namespace SEI_LOGIN.Forms
{
    public partial class SystemFileUpload : Form
    {
        string _CorpCode = string.Empty;

        public SystemFileUpload()
        {
            InitializeComponent();
            cmbDownFolder.SelectedIndex = 0;
            DisplayUploadedFiles();
        }

        public SystemFileUpload(string CorpCode)
        {
            InitializeComponent();
            _CorpCode = CorpCode;
            cmbDownFolder.SelectedIndex = 0;
            DisplayUploadedFiles();
        }

        private void DisplayUploadedFiles()
        {
            UploadedList.Items.Clear();

            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_S", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@CD_CORP", _CorpCode);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UploadedList.Items.Add(new ListViewItem(new string[]
                    {
                        reader["NM_FILE"].ToString(),
                        reader["DT_FILE"].ToString(),
                        reader["NM_DOWNFOLDER"].ToString()
                    }));
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All Files|*.*",
                Title = "Select Files to Upload"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    AddList.Items.Add(new ListViewItem(new string[] { fileName, System.IO.Path.GetFileName(fileName) }));
                }
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // 프로그레스 바 초기화
            progressBar.Value = 0;
            progressBar.Maximum = AddList.Items.Count;

            foreach (ListViewItem listItem in AddList.Items)
            {
                string filePath = listItem.Text;
                FileUpload(filePath);

                progressBar.Value++;
            }

            DisplayUploadedFiles();

            AddList.Items.Clear();
        }

        private void FileUpload(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string fileCreatedAt = File.GetCreationTime(filePath).ToString("yyyyMMddHH24d");
            FileInfo fileInfo = new FileInfo(filePath);

            long fileSize = fileInfo.Length;
            byte[] filedata = Util.ReadFile(fileInfo.FullName);

            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_D", con))
                {
                    cmd.Parameters.AddWithValue("@CD_CORP", _CorpCode);
                    cmd.Parameters.AddWithValue("@NM_FILE", fileName);
                    cmd.Parameters.AddWithValue("@NM_DOWNFOLDER", cmbDownFolder.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_I", con))
                {
                    cmd.Parameters.AddWithValue("@CD_CORP", _CorpCode);
                    cmd.Parameters.AddWithValue("@NM_FILE", fileName);
                    cmd.Parameters.AddWithValue("@NM_DOWNFOLDER", cmbDownFolder.Text);
                    cmd.Parameters.AddWithValue("@DT_FILE", fileCreatedAt);
                    cmd.Parameters.AddWithValue("@FL_FILESIZE", fileSize);
                    cmd.Parameters.AddWithValue("@IM_FILEDATA", filedata);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                tran.Commit();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 프로그레스 바 초기화
            progressBar.Value = 0;
            progressBar.Maximum = UploadedList.SelectedItems.Count;

            // 선택된 항목들을 반복하며 삭제
            foreach (ListViewItem selectedItem in UploadedList.SelectedItems)
            {
                // 삭제 작업을 수행
                string fileName = selectedItem.Text;
                FileDelete(fileName);
                UploadedList.Items.Remove(selectedItem);

                // 프로그레스 바 업데이트
                progressBar.Value++;
            }
        }

        private void FileDelete(string fileName)
        {
            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_D", con))
                {
                    cmd.Parameters.AddWithValue("@CD_CORP", _CorpCode);
                    cmd.Parameters.AddWithValue("@NM_FILE", fileName);
                    cmd.Parameters.AddWithValue("@NM_DOWNFOLDER", cmbDownFolder.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                tran.Commit();
            }
        }
    }
}
