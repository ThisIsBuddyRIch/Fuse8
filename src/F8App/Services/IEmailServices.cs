using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace F8App.Services
{
    public interface IEmailServices
    {
       void SendMessage(string mail, string pathAttach);
    }

    public enum SmtpServerType
    {
        GMail,
        Yandex,
        MailRu
    }

}


