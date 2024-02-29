using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.DTOS.Email
{
    public static class ConfigurationDTO
    {
        public static SmtpConfiguracao Smtp = new SmtpConfiguracao();
        public class SmtpConfiguracao
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
