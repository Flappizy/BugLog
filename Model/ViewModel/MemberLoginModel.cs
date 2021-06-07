using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Buglog.Model.ViewModel
{
    public class MemberLoginModel
    {
        [Required]
        [Remote("UserNameKey", "Validate", ErrorMessage = "UserName already exist")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Remote("EmailKey", "Validate", ErrorMessage = "Email already exist")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
