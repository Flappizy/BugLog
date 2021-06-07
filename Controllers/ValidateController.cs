using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Buglog.Model.IdentityModels;

namespace BugLog.Controllers
{
    //This class is used to validate if a UserName or Email already exists in the process of registering
    [ApiController]
    [Route("api[controller]")]
    public class ValidateController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public ValidateController(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }
        
        //This action method is used to validate if a username exists in the process of registration
        [HttpGet("usernamekey")]
        public async Task<bool> UserNameKey(string username)
        {
            bool userNameExist = await userManager.FindByNameAsync(username) != null;
            return !userNameExist;
        }

        //This action method is used to validate if an email exists in the process of registration
        [HttpGet("emailkey")]
        public async Task<bool> EmailKey(string email)
        {
            bool userNameExist = await userManager.FindByEmailAsync(email) != null;
            return !userNameExist;
        }
    }
}
