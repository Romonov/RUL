using Newtonsoft.Json;
using StriveEngine;
using StriveEngine.Core;
using StriveEngine.Tcp.Passive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RUL.Magicpush
{
    public class Notice
    {
        /// <summary>
        /// 获取魔推的公告消息
        /// </summary>
        /// <returns>公告消息列表</returns>
        public static List<Structures.Notice> Get()
        {
            List<Structures.Notice> list = new List<Structures.Notice>();

            WebRequest request = WebRequest.Create("http://magicpush.romonov.com/Notice");

            ((HttpWebRequest)request).UserAgent = "Magicpush Client";

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            string[] str = responseFromServer.Split('}');

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == "")
                    break;
                str[i] += "}";
                list.Add(JsonConvert.DeserializeObject<Structures.Notice>(str[i]));
            }
            return list;
        }

        /*
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://magicpush.romonov.com/Notice");
        req.Method = "GET";
        using (WebResponse wr = req.GetResponse())
        {

            string notice = wr.ToString();// Todo
            byte[] byteArray = Encoding.Default.GetBytes(notice);


        }
    }
    public static string GetHttp(string url, HttpContent httpContext)
    {
        string queryString = "?";
        foreach (string key in httpContext.Request.QueryString.AllKeys)
        {
            queryString += key + "=" + httpContext.Request.QueryString[key] + "&";
        }
        queryString = queryString.Substring(0, queryString.Length - 1);
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url + queryString);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "GET";
        httpWebRequest.Timeout = 20000;
        byte[] btBodys = Encoding.UTF8.GetBytes(body);
        httpWebRequest.ContentLength = btBodys.Length;
        httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
        string responseContent = streamReader.ReadToEnd();
        httpWebResponse.Close();
        streamReader.Close();
        return responseContent;
    }


    // Todo
    /*
    private ITcpPassiveEngine tcpPassiveEngine;

    public static Get()
    {

    }

    void Init()
    {
        try
        {
            tcpPassiveEngine = NetworkEngineFactory.CreateTextTcpPassiveEngine("magicpush.romonov.com", 45679, new DefaultTextContractHelper("\0"));
            tcpPassiveEngine.MessageReceived += new CbDelegate<IPEndPoint, byte[]>(tcpPassiveEngine_MessageReceived);
            tcpPassiveEngine.AutoReconnect = false;               
            tcpPassiveEngine.ConnectionInterrupted += new CbDelegate(tcpPassiveEngine_ConnectionInterrupted);
            tcpPassiveEngine.ConnectionRebuildSucceed += new CbDelegate(tcpPassiveEngine_ConnectionRebuildSucceed);
            tcpPassiveEngine.Initialize();

            Logger.Info("Successful!");
        }
        catch (Exception e)
        {
            Logger.Error(e.Message);
        }

        tcpPassiveEngine.CloseConnection();
    }

    void tcpPassiveEngine_ConnectionRebuildSucceed()
    {
        Logger.Info("Reconnect successfully!");
    }

    void tcpPassiveEngine_ConnectionInterrupted()
    {
        Logger.Info("Disconnected!");
    }

    void tcpPassiveEngine_MessageReceived(IPEndPoint serverIPE, byte[] bMsg)
    {
        string msg = Encoding.UTF8.GetString(bMsg); //消息使用UTF-8编码
        msg = msg.Substring(0, msg.Length - 1); //将结束标记"\0"剔除
        Get(msg);
    }

    private void Send(object sender, EventArgs e)
    {
        string msg = this.textBox_msg.Text + "\0";// "\0" 表示一个消息的结尾
        byte[] bMsg = Encoding.UTF8.GetBytes(msg);//消息使用UTF-8编码
        this.tcpPassiveEngine.SendMessageToServer(bMsg);
    }
    */
    }
}
