using StriveEngine;
using StriveEngine.Core;
using StriveEngine.Tcp.Passive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RUL.Magicpush
{
    class Notice
    {
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
