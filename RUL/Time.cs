using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RUL
{
    public class Time
    {
        public static string GetUnixTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToString(ts.TotalSeconds * 1000);
        }

        public static string GetUnixTimeStamp(DateTime dateTime)
        {
            TimeSpan ts = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToString(ts.TotalSeconds * 1000);
        }
    }
}
