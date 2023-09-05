using SEI_LOGIN.Forms;
using System.Diagnostics;

namespace SEI_LOGIN
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var processName = Process.GetCurrentProcess().ProcessName;
            bool isNew;
            _ = new Mutex(true, processName, out isNew);

            if (!isNew)
            {
                MessageBox.Show("이미 실행중 입니다!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}