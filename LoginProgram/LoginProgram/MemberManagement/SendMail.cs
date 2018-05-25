using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LoginProgram
{
    class SendMail
    {
        DAO dao;

        string SMTP_SERVER = "smtp.naver.com";
        int SMTP_PORT = 587;
        string senderID = "fewus28@naver.com";
        string senderName = "fewus28";
        string senderPassword = "3dlatjzh)!";

        public SendMail(DAO dao)
        {
            this.dao = dao;
        }

        public bool Send(string phone, string email)
        {
            string[] account = new string[2];

            account = dao.FindAccount(phone);
            if(account == null)
                return false;

            MailAddress mailFrom = new MailAddress(senderID, senderName);
            MailAddress mailTo = new MailAddress(email);

            SmtpClient client = new SmtpClient(SMTP_SERVER, SMTP_PORT);
            MailMessage message = new MailMessage(mailFrom, mailTo);

            message.Subject = "너의 아이디와 비밀번호를 알려주겠다 촤하하";
            message.Body = "너의 아이디는 " + account[0] + " 이고 비밀번호는 " + account[1] + " 이니라... 착하게 살거라..";
            message.BodyEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.UTF8;

            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
            client.Send(message);
            return true;
        }
    }
}
