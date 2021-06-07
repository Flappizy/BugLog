using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Services;

namespace Buglog.Contracts
{
    //This is an interface for sending an email
    public interface IMailService
    {
        Task SendInviteEmailAsync(MailInfo mailInfo);
    }
}
