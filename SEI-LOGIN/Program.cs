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
            // �̹� ���� ���� ���μ��� �̸� Ȯ��
            string currentProcessName = Process.GetCurrentProcess().ProcessName;
            Process[] runningProcesses = Process.GetProcessesByName(currentProcessName);

            // ���� ���μ����� ������ ������ �̸��� ���μ����� ���� ���� ��� ���� ����
            if (runningProcesses.Length > 1)
            {
                MessageBox.Show("���α׷��� �̹� ���� ���Դϴ�.", "���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // ���� ����
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