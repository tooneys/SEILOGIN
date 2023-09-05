using System.Runtime.InteropServices;
using System.Text;

namespace SEI_LOGIN.Common
{
    internal class Util
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string Trim(String str)
        {
            return str.Trim();
        }

        public static string ReadIniFile(string section, string key, string path)
        {
            if (!System.IO.File.Exists(path)) return "";

            StringBuilder sb = new StringBuilder(255);

            try
            {
                GetPrivateProfileString(section, key, "", sb, sb.Capacity, path);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return sb.ToString();
        }
    }
}
