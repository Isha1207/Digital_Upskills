using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DigitaalUpskills.Utills
{
    public static class EmailProvider
    {
        public static void Email(string receiverEmail ,string emailSubject, string mailBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ishaislam1207@gmail.com");
                message.To.Add(new MailAddress("receiverEmail"));
                message.Subject = emailSubject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = mailBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ishaislam1207@gmail.com", "ooaddbms1822");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}