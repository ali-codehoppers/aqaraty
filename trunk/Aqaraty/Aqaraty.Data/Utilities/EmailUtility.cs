using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Aqaraty.Data.Utilities
{
    public class EmailUtility
    {
        private static string FROM_ADDRESS = ConfigurationManager.AppSettings.Get(WebConstants.Config.FROM_EMAIL_ADDRESS);
        private static string SMTP_SERVER = "smtp.gmail.com";
        private static string USER_NAME = "test.aqaraty";
        private static string PASSWORD = "aqaraty123";

        public static void SendPasswordEmail(string email,string subject,string contents)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(email);
                message.Subject = subject;
                message.From = new System.Net.Mail.MailAddress("no-reply@test-aqaraty.com");
                message.Body = contents;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(SMTP_SERVER);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(USER_NAME, PASSWORD);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = SMTPUserInfo;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
