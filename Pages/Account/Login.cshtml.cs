using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Buglog.Model;
using Buglog.Repository;
using Buglog.Contracts;
using System.ComponentModel.DataAnnotations;
using Buglog.Model.IdentityModels;

namespace Buglog.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> signInManager;
        public UserManager<ApplicationUser> UserManager { get; set; }
        private IMembersRepo _memberRepo;

        public LoginModel(SignInManager<ApplicationUser> signIn, UserManager<ApplicationUser> userManager, IMembersRepo memberRepo)
        {
            signInManager = signIn;
            UserManager = userManager;
            _memberRepo = memberRepo;
        }

        [Required]
        [BindProperty]
        public string UserName { get; set; }

        [Required]
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(UserName);
            
            if (user != null)
            {
                Member member = await _memberRepo.GetMemberByUser(user.UserName);
                bool isInRoleGuest = await UserManager.IsInRoleAsync(user, "Guest");
                bool isInRoleDev = await UserManager.IsInRoleAsync(user, "Developer");

                if ((member != null) || isInRoleDev || isInRoleGuest)
                {
                    TempData["Message"] = "You can not Login through here, because you were invited, log in through the invite" +
                        " sent to your mail";
                    return Page();
                }
            }
           

            if (user == null)
            {
                TempData["Message"] = "Invalid Username, please register then log in";
                return Page();
            }

            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(UserName, Password, false, false);
                if (result.Succeeded)
                {
                  return  Redirect("/home/index");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return Page();
        }
    }
}
