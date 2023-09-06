using System.Runtime.InteropServices;
using System.Text;

namespace SEI_LOGIN.Common
{
    internal class Util
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

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

        public static void WriteIniFile(string section, string key, string value, string path)
        {
            try
            {
                WritePrivateProfileString(section, key, value, path);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public static byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            br.Close();
            fStream.Close();
            return data;
        }
    }
}
