using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace RUL.Net
{
    public class HttpProtocol
    {
        public static HttpReq Solve(string req)
        {
            HttpReq ret = new HttpReq();

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
                if (con.Length > 2)
                {
                    string[] get_datas = con[2].Split('&');
                    foreach (string s in get_datas)
                    {
                        getdata.Add(s.Split('=')[0], s.Split('=')[1]);
                    }
                    ret.Get = getdata;
                }


                // Post
                if (ret.Method == Method.Post)
                {
                    string postdata = "";

                    string post_data = lines[lines.Length - 1];
                    if (post_data != "")
                    {
                        postdata += post_data;
                    }
                    ret.PostData = postdata;
                }

                // UA
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tmp = lines[i].Split(':');
                    if (tmp[0] == "User-Agent")
                    {
                        ret.UA = tmp[1];
                        /*
                        for (int j = 2; j < tmp.Length; j++)
                            ret.UA = $" {tmp[j]}";
                        */
                    }
                }

                // RealIP
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tmp = lines[i].Split(':');
                    if (tmp[0] == "X-Forwarded-For")
                    {
                        ret.From = tmp[1];
                        break;
                    }
                }

                // Connection
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tmp = lines[i].Split(':');
                    if (tmp[0] == "Connection")
                    {
                        if (tmp[1].Contains("keep-alive"))
                        {
                            ret.Connection = Connection.KeepAlive;
                            break;
                        }
                        if (tmp[1].Contains("close"))
                        {
                            ret.Connection = Connection.Close;
                            break;
                        }
                        ret.Connection = Connection.Other;
                    }
                }
            }
            return ret;
        }

        public static string Build(int Stat, string ContentType, int ContentLng, Dictionary<string, string> ResponseHead)
        {
            string ResponseHeadAdd = "";

            foreach (var item in ResponseHead)
            {
                ResponseHeadAdd += $"{item.Key}: {item.Value}\r\n";
            }

            return $"HTTP/1.1 {Stat} \r\nContent-Type: {ContentType};charset=UTF-8 \r\nContent-Length: {ContentLng} \r\n{ResponseHeadAdd}\r\n\r\n";
        }

        public static string Build(int Stat, string ContentType, int ContentLng)
        {
            return $"HTTP/1.1 {Stat} \r\nContent-Type: {ContentType};charset=UTF-8 \r\nContent-Length: {ContentLng}\r\n\r\n";
        }
    }

    public struct HttpReq
    {
        public string Url;
        public Method Method;
        public Dictionary<string, string> Get;
        public string PostData;
        public string UA;
        public string From;
        public Connection Connection;

        // Todo
        public Protocol ReqProtocol;
        public string[] AcceptType;
        public string[] AcceptEncoding;
        public string[] AcceptLanguage;
        public string Cookies;
    }

    public enum Method
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

    public enum Connection
    {
        Close,
        KeepAlive,
        Other
    }
}