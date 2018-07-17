using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUL.HTTP
{
    class HttpProtocol
    {
        public static HttpMsg Solve(string req)
        {
            HttpMsg ret = new HttpMsg();

            string[] lines = req.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (lines.Length > 0)
            {
                // GET
                string[] getreqs = lines[0].Split(' ');
                ret.GetUrl = getreqs[1];

                // POST
                Dictionary<string, string> postdata = new Dictionary<string, string>();
                if (lines.Contains(""))
                {
                    ret.Method = Method.Post;
                    string post_data = lines[lines.Length - 1];
                    if (post_data != "")
                    {
                        string[] post_datas = post_data.Split('&');
                        foreach (string s in post_datas)
                        {
                            postdata.Add(s.Split('=')[0], s.Split('=')[1]);
                        }
                    }
                    ret.Post = postdata;
                }
                else
                {
                    ret.Method = Method.Get;
                }

                // UA
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tmp = lines[i].Split(' ');
                    if (tmp[0] == "User-Agent:")
                    {
                        ret.UA = tmp[1];
                        for (int j = 2; j < tmp.Length; j++)
                            ret.UA += $" {tmp[j]}";
                    }
                }
            }
            return ret;
        }

        public static string Make(int stat, string contentType, int contentLng)
        {
            return $"HTTP/1.1 {stat} \r\n" + $"Content-Type:{contentType};charset=UTF-8\r\nContent-Length:{contentLng}\r\n\r\n";
        }
    }

    struct HttpMsg
    {
        public string GetUrl;
        public Method Method;
        public string UA;
        public Dictionary<string, string> Post;
    }

    enum Method
    {
        Get,
        Post,
        Head,
        Put,
        Delete,
        Options,
        Trace,
        Conntect
    }
}
