using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;
using System.Net;
using System.Windows;

namespace UngDungHenHo.BS_layer
{
    public class BLForgetpass
    {
        DBMain dbMain;
        int oTP;
        public BLForgetpass()
        {
            dbMain = new DBMain();
        }

        public int OTP { get => oTP; set => oTP = value; }

        public bool SendCode(string username, string email)
        {
            Random random = new Random();
            this.oTP = random.Next(1000, 10000);

            string fromEmail = "trunghausender@gmail.com";
            string password = "fszliuunmevmvfrs";

            string toEmail = email;

            MailMessage mailMessage = new MailMessage(fromEmail, toEmail);
            mailMessage.Subject = "OTP to change your password";
            mailMessage.Body = "OTP: " + oTP.ToString();
            mailMessage.IsBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(fromEmail, password);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public bool CheckCode(string code)
        {
            return code == OTP.ToString(); 
        }

        public bool ChangPass(string username, string password)
        {
            

            return true;
        }
    }
}
