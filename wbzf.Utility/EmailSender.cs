using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace wbzf.Utility
{
    public class EmailSender : IEmailSender
    {
        //string host = "smtpout.secureserver.net";
        //int port = 587;
        //string fromAddress = "info@acpind.com";
        //string userName = "info@acpind.com";
        //string password = "Acpind$2022";
        string host { get; set; }
        int port { get; set; }
        string fromAddresss { get; set; }
        string userName { get; set; }
        string password { get; set; }
        public EmailSender(IConfiguration _config)
        {
            host = _config.GetValue<string>("smtp:host");
            port = _config.GetValue<int>("smtp:port");
            fromAddresss = _config.GetValue<string>("smtp:fromEmail");
            userName = _config.GetValue<string>("smtp:username");
            password = _config.GetValue<string>("smtp:password");
        }
        
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(fromAddresss);
                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(email));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = userName;
                NetworkCred.Password = password;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = port;
                smtp.Send(mailMessage);
            }



            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("hello@dotnetmastery.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };


            ////send email
            //using (var emailClient = new SmtpClient())
            //         {
            //	emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //	emailClient.Authenticate("dotnetmastery@gmail.com", "");
            //	emailClient.Send(emailToSend);
            //	emailClient.Disconnect(true);
            //         }
            return Task.CompletedTask;
        }
    }
}
