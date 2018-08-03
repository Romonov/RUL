using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RUL.HTTP
{
    class HttpProtocol
    {
        public static Request Solve(string req)
        {
            Request ret = new Request();

            string[] lines = req.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (lines.Length > 0)
            {
                // GET
                string[] getreqs = lines[0].Split(' ');
                string[] getcon = getreqs[1].Split('?');
                ret.Url = getcon[0];

                //GetData
                Dictionary<string, string> getdata = new Dictionary<string, string>();

                string[] get_datas = getcon[2].Split('&');
                foreach (string s in get_datas)
                {
                    getdata.Add(s.Split('=')[0], s.Split('=')[1]);
                }
                ret.Get = getdata;

                // POST
                Dictionary<string, string> postdata = new Dictionary<string, string>();
                if (lines.Contains(""))
                {
                    ret.ReqType = Method.Post;
                    string post_data = lines[lines.Length - 1];
                    if (post_data != "")
                    {
                        ret.Post = post_data;
                    }
                }
                else
                {
                    ret.ReqType = Method.Get;
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

    struct Request
    {
        public Method ReqType;
        public Protocol ReqProtocol;
        public string Url;
        public IPAddress From;
        public Dictionary<string, string> Get;
        public string UA;
        public string[] AcceptType;
        public string[] AcceptEncoding;
        public string[] AcceptLanguage;
        public string Cookies;
        public string Post;
    }

    enum Method
    {
        Get = 0,
        Post = 1,
        Head = 2,
        Put = 3,
        Delete = 4,
        Options = 5,
        Trace = 6,
        Conntect = 7
    }

    enum Protocol
    {
        HTTP10,
        HTTP11,
        HTTPS
    }
}