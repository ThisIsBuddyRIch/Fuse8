using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace F8App.Services
{
    public interface IEmailServices
    {
        void SendMessage(SmtpServerType smtp, Stream message);
    }

    public enum SmtpServerType
    {
        GMail,
        Yandex,
        MailRu
    }

}


