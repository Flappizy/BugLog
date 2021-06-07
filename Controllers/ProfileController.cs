using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Buglog.Model.IdentityModels;
using Buglog.Model.ViewModel;

namespace BugLog.Controllers
{
    //This controller handles the profile page of a user
    public class ProfileController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IEnumerable<string> Roles { get; set; }

        public ProfileController(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }

        //This action method displays the profile information of a user
        public async Task<IActionResult> ShowProfile()
        {
            ApplicationUser user = await userManager.FindByNameAsync(User.Identity.Name);
            Roles =  await userManager.GetRolesAsync(user);

            ProfileModel viewModel = new ProfileModel
            {
                AppUser = user,
                Roles = Roles
            };


            return View(viewModel);
        }
    }
}
