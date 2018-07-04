/**
 * RUL.SQL
 * Ver: 0.1.0
 * Date: 2018.7.1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace RUL.SQL
{
    class MsSql
    {
        public static void Init(string server, string db, string user, string pw)
        {
            SqlConnection connection = new SqlConnection();
            string connectionString = $"server={server};database={db};uid={user}; pwd={pw}";
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public static string Do()
        {

            return "";
        }

        public static string Find(string sheet, string key)
        {

            return "";
        }
    }
}