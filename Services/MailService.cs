using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;
using Buglog.Contracts;

namespace Buglog.Services
{
    //This class is used to send an email
    public class MailService : IMailService
    {
        public MailSettings MailSettings { get; set; }
        
        public MailService(IOptions<MailSettings> mailSettings)
        {
            MailSettings = mailSettings.Value;
        }
        
        public async Task SendInviteEmailAsync(MailInfo mailInfo)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\Templates\\InviteTemplate.html";
            StreamReader read = new StreamReader(filePath);
            string mailText = read.ReadToEnd();
            read.Close();
            mailText = mailText.Replace("[User]", mailInfo.User);
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(MailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailInfo.RecieverMail));
            email.Subject = $"BugLog Invite from {mailInfo.User}";
            var builder = new BodyBuilder();
            builder.HtmlBody = mailText;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(MailSettings.Host, MailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(MailSettings.Mail, MailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }

        }
    }
}
