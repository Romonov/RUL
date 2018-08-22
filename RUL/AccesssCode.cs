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
            return MD5(MD5(Password) + TimeStamp());
        }

        private static string MD5(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(strText));
            return Encoding.Default.GetString(result);
        }

        private static string TimeStamp()
        {
            string y = DateTime.Now.Year.ToString();
            string M = DateTime.Now.Month.ToString();
            string d = DateTime.Now.Day.ToString();
            string H = DateTime.Now.Hour.ToString();
            string m = DateTime.Now.Minute.ToString();

            switch (M)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    M = "0" + M;
                    break;
                default:
                    break;
            }

            switch (d)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    d = "0" + d;
                    break;
                default:
                    break;
            }

            switch (H)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    H = "0" + H;
                    break;
                default:
                    break;
            }

            switch (m)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    m = "0" + m;
                    break;
                default:
                    break;
            }

            return y + M + d + H + m;
        }
    }
}
