using System;
using System.Windows.Forms;

namespace SEI_LOGIN.Common
{
    public class MBox  
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
