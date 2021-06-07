using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Buglog.Model;
using Microsoft.AspNetCore.Identity;
using Buglog.Model.IdentityModels;
using Buglog.Data;

namespace Buglog.Pages
{
    public class NewProjectModel : PageModel
    {
        [BindProperty]
        public Project Project { get; set; }
        
        public AppDbContext Context { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }


        public NewProjectModel(AppDbContext dbContext, UserManager<ApplicationUser> userManager )
        {
            Context = dbContext;
            UserManager = userManager;
        }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name); 
            if (ModelState.IsValid)
            {
                Project.User = user.Administrator; 
                Context.Projects.Add(Project);
                await Context.SaveChangesAsync(user.UserName, user.Administrator);
                return Redirect("/home/index");
            }
            return Page();
        }
    }
}
