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
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToString();
        }

        private static string TimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmm");
        }
    }
}
