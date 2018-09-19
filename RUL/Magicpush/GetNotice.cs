/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RUL.Magicpush
{
    public class GetNotice
    {
        /// <summary>
        /// 获取魔推的公告消息
        /// </summary>
        /// <returns>公告消息列表</returns>
        public static List<Notice> Get()
        {
            List<Notice> list = new List<Notice>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://magicpush.romonov.com:45679/notice");
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.Default);
            string returnString = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();

            MpNotices Notices = JsonConvert.DeserializeObject<MpNotices>(returnString);
            for (int i = 0; i < MpNotices.Notices.Length; i++)
            {
                list.Add(MpNotices.Notices[i]);
            }

            return list;
        }
    }

    public struct Notice
    {
        public int ID;
        public string Title;
        public string Detail;
        public string Date;
        public string Time;
        public string Link;
        public int ColorR;
        public int ColorG;
        public int ColorB;
    }

    public struct MpNotices
    {
        public static Notice[] Notices;
    }

    public struct Update
    {
        public int ID;
        public string Project;
        public string UpdateLog;
        public string Date;
        public string Time;
        public string DetailLink;
        public string DownloadLink;
        public int ColorR;
        public int ColorG;
        public int ColorB;
    }
}
*/