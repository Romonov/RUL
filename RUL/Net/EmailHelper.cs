using System;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace RUL.Net
{
    class EmailHelper
    {
        public static bool MailSend(EmailParam EmailParams)
        {
            try
            {
                using (SmtpClient sendSmtpClient = new SmtpClient(EmailParams.SendSmtp))
                {
                    MailAddress sendMailAddress = new MailAddress(EmailParams.SendEmail, EmailParams.SendTitle, Encoding.UTF8);
                    MailAddress consigneeMailAddress = new MailAddress(EmailParams.ConsigneeAddress, EmailParams.ConsigneeName, Encoding.UTF8);
                    using (MailMessage mailMessage = new MailMessage(sendMailAddress, consigneeMailAddress))
                    {
                        mailMessage.Subject = EmailParams.SendSubject;
                        mailMessage.SubjectEncoding = Encoding.UTF8;

                        mailMessage.Body = EmailParams.SendContent;
                        mailMessage.BodyEncoding = Encoding.UTF8;
                        mailMessage.IsBodyHtml = false;

                        sendSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sendSmtpClient.EnableSsl = false;

                        sendSmtpClient.UseDefaultCredentials = false;

                        NetworkCredential myCredential = new NetworkCredential(EmailParams.SendEmail, EmailParams.SendPwd);
                        sendSmtpClient.Credentials = myCredential;
                        sendSmtpClient.Send(mailMessage);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class EmailParam
    {
        /// <summary>
        /// 邮件服务器
        /// </summary>
        public string SendSmtp { get; set; }

        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string SendEmail { get; set; }

        /// <summary>
        /// 发件人邮件密码
        /// </summary>
        public string SendPwd { get; set; }

        /// <summary>
        /// 发件标题
        /// </summary>
        public string SendTitle { get; set; }

        /// <summary>
        /// 发件主题
        /// </summary>
        public string SendSubject { get; set; }

        /// <summary>
        /// 发件内容
        /// </summary>
        public string SendContent { get; set; }

        /// <summary>
        /// 发件内容是否为Html
        /// </summary>
        public bool IsSendContentHtml { get; set; }

        /// <summary>
        /// 收件人邮件地址 
        /// </summary>
        public string ConsigneeAddress { get; set; }

        /// <summary>
        /// 收件人名称
        /// </summary>
        public string ConsigneeName { get; set; }




    }
}
