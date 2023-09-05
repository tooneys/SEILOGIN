using System.Security.Cryptography;
using System.Text;

namespace SEI_LOGIN.Common
{
    internal class Security
    {
        private static string encKey = "K-Giant!";

        // 암호화 하고자 하는 Key 값(String) 을 받아서 DES 알고리즘으로 암호화한 문자열을 Return 함
        public static String Encrypt(String strKey)
        {
            if (strKey.Length == 0)
                return "";

            byte[] pbyteKey;
            pbyteKey = ASCIIEncoding.ASCII.GetBytes(encKey);

            DESCryptoServiceProvider desCSP = new DESCryptoServiceProvider();
            desCSP.Mode = CipherMode.ECB;
            desCSP.Padding = PaddingMode.PKCS7;
            desCSP.Key = pbyteKey;
            desCSP.IV = pbyteKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(ms, desCSP.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] data = Encoding.UTF8.GetBytes(strKey.ToCharArray());
            cryptStream.Write(data, 0, data.Length);
            cryptStream.FlushFinalBlock();

            String strReturn = Convert.ToBase64String(ms.ToArray());
            cryptStream = null;
            ms = null;
            desCSP = null;
            return strReturn;
        }

        // DES 알고리즘으로 암호화된 문자열을 받아서 복호화 한 후 암호화 이전의 원래 문자열을 Return 함
        public static String Decrypt(String strKey)
        {
            if (strKey.Length == 0)
                return "";

            byte[] pbyteKey;
            pbyteKey = ASCIIEncoding.ASCII.GetBytes(encKey);

            DESCryptoServiceProvider desCSP = new DESCryptoServiceProvider();
            desCSP.Mode = CipherMode.ECB;
            desCSP.Padding = PaddingMode.PKCS7;
            desCSP.Key = pbyteKey;
            desCSP.IV = pbyteKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(ms, desCSP.CreateDecryptor(), CryptoStreamMode.Write);
            strKey = strKey.Replace(" ", "+");
            byte[] data = Convert.FromBase64String(strKey);
            cryptStream.Write(data, 0, data.Length);
            cryptStream.FlushFinalBlock();

            String strReturn = Encoding.UTF8.GetString(ms.ToArray());

            cryptStream = null;
            ms = null;
            desCSP = null;

            return strReturn;
        }
    }
}
