using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Buglog.Data;
using Buglog.Model;

namespace Buglog.Services
{
    //This class is used to model an invitation sent
    public class MailInfo
    {
        
        public MailInfo()
        {
        }
        
        [Required]
        public string RecieverMail { get; set; }
        [Required]
        public string AssignedRole { get; set; }
        public string User { get; set; }
        public IEnumerable<IdentityRole> Roles = Enumerable.Empty<IdentityRole>();
 
    }
}
