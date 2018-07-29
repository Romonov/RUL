/**
 * RUL.INI
 * Ver: 1.0.0
 * Date: 2018.7.1
 */

using System.Text;
using System.Runtime.InteropServices;

namespace RUL
{
    public class INI
    {
        /// <summary>
        /// 写入INI文件方法
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        [DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
        private static extern long WritePrivateProfileString(
            string section,
            string key,
            string val,
            string filePath
         );

        /// <summary>
        /// 读取INI文件方法
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retVal">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(
            string section,
            string key,
            string def,
            StringBuilder retVal,
            int size,
            string filePath
        );

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="ini_file_path">文件路径</param>
        /// <param name="ini_file_name">文件名</param>
        /// <param name="section">节点名</param>
        /// <param name="key">键</param>
        /// <returns>该键的值</returns>
        public static string Read(string ini_file_path, string ini_file_name, string section, string key)
        {
            string ini_file_path_full = "";
            if ((ini_file_path != "null" || ini_file_path != "") && (ini_file_name != "null" || ini_file_name != ""))
            {
                ini_file_path_full = ini_file_path + ini_file_name;
            }
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", temp, 1024, ini_file_path_full);
            return temp.ToString();
        }

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="ini_file_path">文件路径</param>
        /// <param name="ini_file_name">文件名</param>
        /// <param name="section">节点名</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        public static void Write(string ini_file_path, string ini_file_name, string section, string key, string val)
        {
            string ini_file_path_full = "";

            if ((ini_file_path != "null" || ini_file_path != "") && (ini_file_name != "null" || ini_file_name != ""))
            {
                ini_file_path_full = ini_file_path + ini_file_name;
            }
            WritePrivateProfileString(section, key, val, ini_file_path_full);
        }
    }
}