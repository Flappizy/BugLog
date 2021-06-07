using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Buglog.Model;
using Buglog.Contracts;
using Buglog.Repository;
using Buglog.Data;
using Buglog.Pages.Account;
using Buglog.Model.IdentityModels;

namespace BugLog.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationUser _idUser;
        private IAuditRepo _auditRepo;
        private IProjectRepo _projectRepo;
        private IIssueRepo _issueRepo;
        private IMembersRepo _memberRepo;

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Member> Members { get; set; } = new List<Member>();
        public List<Issue> Issues { get; set; } = new List<Issue>();
        public List<Audit> Activities { get; set; } = new List<Audit>();
        public List<Audit> AllAudits => _dbContext.AuditLogs.ToList();

        public HomeController(AppDbContext dbContext, UserManager<ApplicationUser> userManager, IAuditRepo auditRepo, IProjectRepo projectRepo,
            IMembersRepo membersRepo, IIssueRepo issueRepo )
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _auditRepo = auditRepo;
            _projectRepo = projectRepo;
            _memberRepo = membersRepo;
            _issueRepo = issueRepo;
        }
        
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToPage("/Login");
            }

            //This gets the current user's identity
            _idUser = await _userManager.FindByNameAsync(User.Identity.Name);
            
            //Then i check if the user is an admin or a developer
            bool adminRoleVerification = await _userManager.IsInRoleAsync(_idUser, "Admin");
            bool adminOrDevRoleVerification = await _userManager.IsInRoleAsync(_idUser, "Admin") || await _userManager.IsInRoleAsync(_idUser, "Developer");
            
            //This is used to know if the administrator has any member within the account
            Member member = await _memberRepo.GetMember(_idUser.Administrator);
            
            //Gets the latest added projects and activities
            Projects = await _projectRepo.FindLatestProjectIncludeIssues(_idUser.Administrator);
            Activities = await _auditRepo.GetLatestActivities(_idUser.Administrator);

            //If there is a member, then we get the members associated with the account
            if (member != null)
            {
                Members = await _memberRepo.FindLatestMembers(_idUser.Administrator);
            }

            //This is basically used to get all the issues within all of the projects registered within the particular account
            foreach (Project project in Projects)
            {
                if (project.ProjectIssues.Count() > 0)
                {
                    Issues.AddRange(project.ProjectIssues);
                }
            }

            //This is used to get the latest issues from all of the issues that was gotten above 
            Issues = _issueRepo.GetLatestIssues(Issues);

            //This is basically the model i return to the view, i assign its properties with values gotten above
            AppViewModel viewModel = new AppViewModel
            { 
                Projects = Projects, 
                Issues = Issues, 
                Members = Members, 
                AdminOrDevRoleVerification = adminOrDevRoleVerification,
                AdminRoleVerification = adminRoleVerification,
                Activities = Activities
            };
            return View(viewModel);
        }
    }
}
