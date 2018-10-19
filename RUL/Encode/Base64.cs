using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RUL.Encode
{
    public class Base64
    {
        public static string Encoder(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        public static string Decoder(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.Default.GetString(bytes);
        }
    }
}
