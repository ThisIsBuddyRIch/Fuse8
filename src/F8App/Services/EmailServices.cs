using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using System.Net;

namespace F8App.Services
{
    public class EmailServices : IEmailServices
    {
        SMTPServerSettings settings = null;

        public EmailServices(IOptions<Options> settings)
        {
            this.settings = settings.Value.SMTPServerSettings;
        }
        

        public void SendMessage(string mail, string pathAttach)
        {
            var from = new MailAddress(settings.Credentials.login);
            var to = new MailAddress(mail);
            var msg = new MailMessage(from, to);
            msg.Subject = "Report";
            msg.Attachments.Add(new Attachment(pathAttach));
            using (var client = new SmtpClient(settings.SmtpSettings[0].host, settings.SmtpSettings[0].port))
            {
                client.Credentials = new NetworkCredential(settings.Credentials.login, settings.Credentials.pass);
                client.EnableSsl = true;
                client.Send(msg);
            }
        }
    }
}
