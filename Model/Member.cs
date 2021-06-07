using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Buglog.Model
{
    //This class is used to model a member
    public class Member
    {
        public Member()
        {
        }

        public long MemberID { get; set; }

        public string User { get; set; }

        [Required(ErrorMessage ="Member requires a User Name")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage ="Member requires an Email address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Assign Member a role")]
        public string AssignedRole { get; set; }
        
        //This should be a dictionary
        public List<Issue> Tasks { get; set; }
    }
}
