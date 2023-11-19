using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;
using System.Net;
using System.Windows;
using System.Data;

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
            string query = $"Select * from THONGTINDANGNHAP where TaiKhoan = '{username}'";
            string error = String.Empty ;
            if (dbMain.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0].Rows.Count == 0)
            {
                return false;
            }

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
            string query = $"UPDATE THONGTINDANGNHAP SET MatKhau = '{password}' WHERE TaiKhoan = '{username}';";
            string error = String.Empty;
            dbMain.MyExecuteNonQuery(query, CommandType.Text, ref error);
            return error == "";
        }
    }
}
