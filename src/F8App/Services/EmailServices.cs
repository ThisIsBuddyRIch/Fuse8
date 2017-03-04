using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace F8App.Services
{
    public class EmailServices : IEmailServices
    {
        public void SendMessage(SmtpServerType smtp, Stream message)
        {
            SmtpClient client;
        }
    }
}
