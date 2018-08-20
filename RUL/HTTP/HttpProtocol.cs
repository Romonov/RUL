using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Maigcpush
{
    class HttpProtocol
    {
        public static HttpMsg Solve(string req)
        {
            HttpMsg ret = new HttpMsg();

            string[] lines = req.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (lines.Length > 0)
            {
                // Url
                string[] reqs = lines[0].Split(' ');
                string[] con = reqs[1].Split('?');
                ret.Url = con[0];

                // Method
                if (reqs[0] == "GET")
                {
                    ret.Method = Method.Get;
                }
                else if (reqs[0] == "POST")
                {
                    ret.Method = Method.Post;
                }
                else
                {
                    ret.Method = Method.Other;
                }

                // Get
                Dictionary<string, string> getdata = new Dictionary<string, string>();

                string[] get_datas = con[2]?.Split('&');
                foreach (string s in get_datas)
                {
                    getdata.Add(s?.Split('=')[0], s?.Split('=')[1]);
                }
                ret.Get = getdata;


                // Post
                if (ret.Method == Method.Post)
                {
                    Dictionary<string, string> postdata = new Dictionary<string, string>();

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

                // UA
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tmp = lines[i].Split(' ');
                    if (tmp[0] == "User-Agent:")
                    {
                        ret.UA = tmp[1];
                        for (int j = 2; j < tmp.Length; j++)
                            ret.UA = $" {tmp[j]}";
                    }
                }

                // RealIP
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tmp = lines[i].Split(' ');
                    if (tmp[0] == "X-Forwarded-For:")
                        ret.From = new IPAddress(Encoding.Default.GetBytes(tmp[1]));
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
        public string Url;
        public Method Method;
        public Dictionary<string, string> Get;
        public Dictionary<string, string> Post;
        public string UA;
        public IPAddress From;

        // Todo
        public Protocol ReqProtocol;
        public string[] AcceptType;
        public string[] AcceptEncoding;
        public string[] AcceptLanguage;
        public string Cookies;
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
        Conntect,
        Other
    }

    public struct Reponse
    {

    }

    public enum Protocol
    {
        HTTP10,
        HTTP11,
        HTTPS
    }

}