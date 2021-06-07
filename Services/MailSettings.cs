using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Services
{
    //This class is used to model the application mail settings
    public class MailSettings
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
