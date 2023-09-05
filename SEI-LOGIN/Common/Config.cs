using System.Reflection;

namespace SEI_LOGIN.Common
{
    internal class Config : ConfigBase
    {
        public static void GetConfigIni()
        {
            string? sProgramName = Assembly.GetExecutingAssembly().GetName().CodeBase;           //프로그램명
            string? sProgramPath = Path.GetDirectoryName(sProgramName?.Replace("file:///", ""));  //프로그램 위치
            string sCommonPath = (sProgramPath + "\\common.ini");

            Config.DBType = System.Configuration.ConfigurationManager.AppSettings["DBType"];
            Config.DBAddress = Security.Decrypt(Util.ReadIniFile("DATABASE", "ADDRESS", sCommonPath));
            Config.DBPort = Security.Decrypt(Util.ReadIniFile("DATABASE", "PORT", sCommonPath));
            Config.DBDatabase = Security.Decrypt(Util.ReadIniFile("DATABASE", "DATABASE", sCommonPath));
            Config.DBUserID = Security.Decrypt(Util.ReadIniFile("DATABASE", "S_UID", sCommonPath));
            Config.DBUserPwd = Security.Decrypt(Util.ReadIniFile("DATABASE", "S_PWD", sCommonPath));
            Config.QUERYTIME = "0";

            switch (Config.DBType)
            {
                case "MSSQL":
                    Config.DBConnectString = "Data Source=" + Config.DBAddress + ";Initial Catalog=" + Config.DBDatabase + ";User ID=" + Config.DBUserID + ";Password=" + Config.DBUserPwd + "; Enlist=false; Connection Timeout=1000000 ;";
                    break;
                case "ORACLE":
                    Config.DBConnectString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + Config.DBAddress + ")(PORT=" + Config.DBPort + "))(CONNECT_DATA=(SERVICE_NAME=" + Config.DBDatabase + "))); User Id=" + Config.DBUserID + ";Password=" + Config.DBUserPwd + ";";
                    break;
                case "OLEDB":
                    Config.DBConnectString = string.Format(System.Configuration.ConfigurationManager.AppSettings["OLEDBConnectString"], Config.DBAddress, Config.DBPort, Config.DBDatabase, Config.DBUserID, Config.DBUserPwd);
                    break;
                case "ODBC":
                    Config.DBConnectString = string.Format(System.Configuration.ConfigurationManager.AppSettings["ODBCConnectString"], Config.DBAddress, Config.DBPort, Config.DBDatabase, Config.DBUserID, Config.DBUserPwd);
                    break;
                default:
                    Config.DBConnectString = "";
                    break;
            }
        }
    }
}
