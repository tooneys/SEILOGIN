﻿using System.Reflection;

namespace SEI_LOGIN.Common
{
    internal class Config : ConfigBase
    {

        public static bool GetConfigIni()
        {
            try
            {
                string? sProgramName = Assembly.GetExecutingAssembly().GetName().CodeBase;           //프로그램명
                string? sProgramPath = Path.GetDirectoryName(sProgramName?.Replace("file:///", ""));  //프로그램 위치
                string sCommonPath = Path.Combine(sProgramPath, "common.ini");

                if (!File.Exists(sCommonPath)) return false;

                Config.DBType = Program.Configuration["DBType"]!;
                Config.DBAddress = Security.Decrypt(Util.ReadIniFile("DATABASE", "ADDRESS", sCommonPath));
                Config.DBPort = Security.Decrypt(Util.ReadIniFile("DATABASE", "PORT", sCommonPath));
                Config.DBDatabase = Security.Decrypt(Util.ReadIniFile("DATABASE", "DATABASE", sCommonPath));
                Config.DBUserID = Security.Decrypt(Util.ReadIniFile("DATABASE", "S_UID", sCommonPath));
                Config.DBUserPwd = Security.Decrypt(Util.ReadIniFile("DATABASE", "S_PWD", sCommonPath));
                Config.QUERYTIME = "0";

                switch (Config.DBType)
                {
                    case "MSSQL":
                        Config.DBConnectString = $"Data Source={Config.DBAddress},{Config.DBPort};Initial Catalog={Config.DBDatabase};User ID={Config.DBUserID};Password={Config.DBUserPwd};Enlist=false;Connection Timeout=1000000;";
                        break;
                    case "ORACLE":
                        Config.DBConnectString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={Config.DBAddress})(PORT={Config.DBPort}))(CONNECT_DATA=(SERVICE_NAME={Config.DBDatabase})));User Id={Config.DBUserID};Password={Config.DBUserPwd};";
                        break;
                    default:
                        Config.DBConnectString = "";
                        break;
                }
                return true;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return false; 
            }
        }

        public static bool SetConfigIni(string DBAddress, string DBPort, string Database, string UID, string PWD)
        {
            try
            {
                if (string.IsNullOrEmpty(DBAddress) ||
                    string.IsNullOrEmpty(DBPort) ||
                    string.IsNullOrEmpty(Database) ||
                    string.IsNullOrEmpty(UID) ||
                    string.IsNullOrEmpty(PWD))
                {
                    MessageBox.Show("모든 필드를 입력하세요.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string initFilePath = Application.StartupPath + "\\common.ini";
                Util.WriteIniFile("DATABASE", "ADDRESS", Security.Encrypt(DBAddress), initFilePath);
                Util.WriteIniFile("DATABASE", "PORT", Security.Encrypt(DBPort), initFilePath);
                Util.WriteIniFile("DATABASE", "DATABASE", Security.Encrypt(Database), initFilePath);
                Util.WriteIniFile("DATABASE", "S_UID", Security.Encrypt(UID), initFilePath);
                Util.WriteIniFile("DATABASE", "S_PWD", Security.Encrypt(PWD), initFilePath);

                MessageBox.Show("저장 되었습니다.", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
