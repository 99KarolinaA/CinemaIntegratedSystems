using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Domain.DomainModels
{
    public class EmailSettings
    {
        //TODO:email
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; } //account na koj isprakame
        public string SmtpPassword { get; set; }
        public int SmtpServerPort { get; set; }
        public bool EnableSsl { get; set; }
        public string EmailDisplayName { get; set; }
        public string SendersName { get; set; }

        public EmailSettings(string smtpServer, string smtpUserName, string smtpPassword, int smtpServerPort)
        {
            SmtpServer = smtpServer;
            SmtpUserName = smtpUserName;
            SmtpPassword = smtpPassword;
            SmtpServerPort = smtpServerPort;
        }

        public EmailSettings()
        {

        }
    }
}
