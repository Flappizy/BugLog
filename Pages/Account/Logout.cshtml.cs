using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Buglog.Model.IdentityModels;

namespace Buglog.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public SignInManager<ApplicationUser> SignInManager { get; set; }
        
        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public async Task OnGet()
        {
            await SignInManager.SignOutAsync();
        }
    }
}
