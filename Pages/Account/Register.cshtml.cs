using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Buglog.Data;
using Buglog.Model.IdentityModels;

namespace Buglog.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private AppIdentityContext _appIdentity;
        
        public UserManager<ApplicationUser> UserManager { get; set; }
        public RoleManager<ApplicationUser> RoleManager { get; set; }
        public string[] roleNames = { "Admin", "User", "Developer" };
        
        public RegisterModel( UserManager<ApplicationUser> manager, AppIdentityContext appIdentity)
        {
            UserManager = manager;
            _appIdentity = appIdentity;
        }

        [Required] [BindProperty] 
        [Remote("UserNameKey", "Validate", ErrorMessage ="UserName already exist")]
        public string UserName { get; set; }

        [Required] [BindProperty] [EmailAddress]
        [Remote("EmailKey", "Validate", ErrorMessage = "Email already exist")]
        public string Email { get; set; }

        [Required] [BindProperty]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = UserName, Email = Email};
                IdentityResult result = await UserManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    user.Administrator = UserName;
                    await UserManager.AddToRoleAsync(user, "Admin");
                    _appIdentity.Update(user);
                    await _appIdentity.SaveChangesAsync();
                    TempData["Message"] = "You have successfully registered"; 
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Page();
        }
    }
}
