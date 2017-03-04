using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F8App
{
    public class Options
    {
        public string ConString { get; set; }

        public SMTPServerSettings SMTPServerSettings { get; set; }
    }

    public class SMTPServerSettings
    {
        public Credentials Credentials { get; set; }

        public SmtpSettings[] SmtpSettings { get; set; }
    }

    public class Credentials
    {
        public string login { get; set; }
        public string pass { get; set; }
    }

    public class SmtpSettings
    {
        public string host { get; set; }
        public int port { get; set; }
    }
}
