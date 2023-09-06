using Microsoft.Extensions.Configuration;
using SEI_LOGIN.Forms;
using System.Diagnostics;

namespace SEI_LOGIN
{
    internal static class Program
    {
        /// <summary>
        /// appsettings.json interface
        /// </summary>
        public static IConfiguration Configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 이미 실행 중인 프로세스 이름 확인
            string currentProcessName = Process.GetCurrentProcess().ProcessName;
            Process[] runningProcesses = Process.GetProcessesByName(currentProcessName);

            // 현재 프로세스를 제외한 동일한 이름의 프로세스가 실행 중인 경우 실행 막기
            if (runningProcesses.Length > 1)
            {
                MessageBox.Show("프로그램이 이미 실행 중입니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 실행 중지
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}