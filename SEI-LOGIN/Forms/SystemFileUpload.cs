using SEI_LOGIN.Common;
using System.Data;
using System.Data.SqlClient;

namespace SEI_LOGIN.Forms
{
    public partial class SystemFileUpload : Form
    {
        public SystemFileUpload()
        {
            InitializeComponent();
            DisplayUploadedFiles();
        }

        private void DisplayUploadedFiles()
        {
            using (SqlConnection con = new SqlConnection(Config.DBConnectString))
            using (SqlCommand cmd = new SqlCommand("SP_SYS_UPDATEFILE_S", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@CD_CORP", "01");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // ListView에 아이템 추가
                    ListViewItem newItem = new ListViewItem("항목1"); // 첫 번째 열에 데이터 추가
                    newItem.SubItems.Add("항목2"); // 두 번째 열에 데이터 추가
                    newItem.SubItems.Add("항목3"); // 세 번째 열에 데이터 추가
                    UploadedList.Items.Add(newItem); // ListView에 아이템 추가
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
