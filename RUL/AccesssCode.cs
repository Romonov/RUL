using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RUL
{
    public class AccesssCode
    {
        /// <summary>
        /// 获取授权码
        /// </summary>
        /// <param name="Password">密码</param>
        /// <returns>授权码</returns>
        public static string GetAccessCode(string Password)
        {
            return GetMD5(GetMD5(Password) + TimeStamp());
        }

        private static string GetMD5(string str)
        {
            string result = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                result = result + s[i].ToString("x2");
            }
            return result;
        }

        private static string TimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
