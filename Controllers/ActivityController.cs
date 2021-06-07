using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Contracts;
using Buglog.Repository;
using Microsoft.AspNetCore.Mvc;
using Buglog.Model;
using Buglog.Model.ViewModel;
using Buglog.Model.Pagination;
using Buglog.Model.Infrastructure;
using Buglog.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Buglog.Controllers
{
    public class ActivityController : Controller
    {
        private IAuditRepo _auditRepo;
        private UserManager<ApplicationUser> _userManager;
        public List<Audit> Activity { get; set; } = new List<Audit>();
        private ApplicationUser _user;

        public ActivityController(IAuditRepo auditRepo, UserManager<ApplicationUser> userManager)
        {
            _auditRepo = auditRepo;
            _userManager = userManager;
        }

        //This method returns all the activities that has taken place within a particular account
        public async Task<IActionResult> ShowActivities(int pageNumber = 1)
        {
            //I get the current user
            _user = await _userManager.FindByNameAsync(User.Identity.Name);
            //Then i get all the activities performed within the account associated with the particular user
            Activity = await _auditRepo.GetActivities(_user.Administrator, pageNumber);
            //I get the amount of activities performed within the account the user is in
            int count = _auditRepo.GetActivitiesCount(_user.Administrator);

            //This is basically the model i return to the users, i assign its properties with values gotten above 
            AuditViewModel viewModel = new AuditViewModel 
            { 
                Audits = Activity,
                //The below property is used for pagination
                PageMetaData = new PageMetaData 
                { 
                    CurrentPage = pageNumber,
                    ItemsPerPage = 3,
                    TotalItems = count,
                    
                },
                //I convert every activities performed in the account into a JSON text
                AuditObject = JsonConverter.ConvertJsonToDictionary(Activity)
            };
            return View(viewModel);
        }
    }
}
