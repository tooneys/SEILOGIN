namespace SEI_LOGIN.Common
{
    internal class ConfigBase
    {
        public static string DBAddress;
        public static string DBPort;
        public static string DBDatabase;
        public static string DBUserID;
        public static string DBUserPwd;
        public static string QUERYTIME;
        public static string DBType;
        public static string DBConnectString;

        public static string ftpPath = "ftp://112.171.126.110:3300/";
        public static string ftpuser = "ftp_user";      //Config.ftp_user;  // FTP 익명 로그인시. 아니면 로그인/암호 지정.
        public static string ftppwd = "Kgiant93957256";  //Config.ftp_pwd;
    }
}