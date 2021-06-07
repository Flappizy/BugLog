using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Buglog.Model.IdentityModels
{
    //This class represents the user
    public class ApplicationUser : IdentityUser
    {
        //This property to represent real owner(inviter) and admin of an account
        public string Administrator { get; set; }
    }
}
