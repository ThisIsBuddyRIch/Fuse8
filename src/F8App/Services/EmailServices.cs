using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace F8App.Services
{
    public class EmailServices : IEmailServices
    {
        SMTPServerSettings settings = null;

        public EmailServices(IOptions<Options> settings)
        {
            this.settings = settings.Value.SMTPServerSettings;
        }



        public void SendMessage(SmtpServerType smtp, Stream message)
        {
            SmtpClient client;
        }
    }
}
