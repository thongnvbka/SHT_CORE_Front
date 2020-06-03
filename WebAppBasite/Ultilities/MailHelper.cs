using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAppBasite.Ultilities
{
    public class MailHelper
    {
        private readonly IConfiguration _configuration;

        //public MailHelper(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public static bool SendMail(string toEmail, string subject, string content)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
            try
            {
                var host = configuration["MailSettings:SMTPHost"];
                var port = int.Parse(configuration["MailSettings:SMTPPort"]);
                var fromEmail = configuration["MailSettings:FromEmailAddress"];
                var password = configuration["MailSettings:FromEmailPassword"];
                var fromName = configuration["MailSettings:FromName"];

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };

                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.BodyEncoding = System.Text.Encoding.UTF8;
               // mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException smex)
            {

                return false;
            }
        }
    }
}
