using System.Security.Cryptography;
using System.Text;

namespace RUL.Encrypt
{
    public class HashWorker
    {
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.Default.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = "";

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }
    }
}
