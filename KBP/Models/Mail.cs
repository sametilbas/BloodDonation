using KBP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace UserIdentity.Models
{
    public class Mail
    {
        public static void MailSender(string body)
        {
            OurDbContext db = new OurDbContext();
            
            string qwe = " SELECT UserID FROM UyeAccount ORDER BY UserID ";
            
            for (int i = 1; i <qwe.Length ; i++)
            {
                UyeAccount uye = db.uyeAccount.Find(i); ;
                if (uye==null)
                {
                    break;
                }
                    UyeAccount a = db.uyeAccount.Find(i);
                    var fromAddress = new MailAddress("kanbagis66@gmail.com");
                    var toAddress = new MailAddress(a.Email);
                    const string subject = "KanBağış | Sitenisinden Gelen Duyuru Formu";
                    using (var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, "kan123qwe")
                    })
                    {
                        using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                        {
                            smtp.Send(message);
                        }
                    }

            }
         
        }
    }
}