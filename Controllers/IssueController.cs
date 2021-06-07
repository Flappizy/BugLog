using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Buglog.Model;
using Buglog.Model.ViewModel;
using Buglog.Contracts;
using Buglog.Model.Pagination;
using Buglog.Data;
using Buglog.Model.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Buglog.Model.IdentityModels;

namespace BugLog.Controllers
{
    //This attribute specify that this controller can be accessed only by users who are within the Admin or Developer role
    [Authorize(Roles = "Admin, Developer")]
    public class IssueController : Controller
    {
        
        public IssueController(AppDbContext dbContext, UserManager<ApplicationUser> userManager, IMembersRepo membersRepo, 
            IProjectRepo projectRepo, IIssueRepo issueRepo, IStatusRepo statusRepo, IPriorityRepo priorityRepo, IAuditRepo auditRepo,
            ICommentRepo commentRepo)
        {
            _dbContext = dbContext;
            UserManager = userManager;
            _membersRepo = membersRepo;
            _projectRepo = projectRepo;
            _issueRepo = issueRepo;
            _statusRepo = statusRepo;
            _priorityRepo = priorityRepo;
            _auditRepo = auditRepo;
            _commentRepo = commentRepo;
        }

        private AppDbContext _dbContext;
        private IMembersRepo _membersRepo;
        private IProjectRepo _projectRepo;
        private IIssueRepo _issueRepo;
        private IAuditRepo _auditRepo;
        private ICommentRepo _commentRepo;
        private IStatusRepo _statusRepo;
        private IPriorityRepo _priorityRepo;
        public IEnumerable<Status> Statuses => _dbContext.Status;
        public IEnumerable<Priority> Priorities => _dbContext.Priority;
        public List<Member> Members { get; set; } = new List<Member>();
        public List<Issue> Issues { get; set; } = new List<Issue>();
        public List<Audit> Activities { get; set; } = new List<Audit>();
        public UserManager<ApplicationUser> UserManager { get; set; }
        [BindProperty]
        public Issue issue { get; set; }
        public ApplicationUser IdUser { get; set; }

        //This method is used to get all the issues that is associated with a particular account 
        //This attribute is used to give access to users that are neither an Admin or a Developer 
        [AllowAnonymous]
        public async Task<IActionResult> ShowIssues(int pageNumber = 1)
        {
            //Gets the current user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            //Gets all the projects and issues within the projects, associated with the particular account
            List<Project> projects = await _projectRepo.FindProjectIncludeIssues(IdUser.Administrator);

            //This is basically used to get all the issues within all of the projects registered within the particular account
            foreach (Project project in projects)
            {
                if (project.ProjectIssues.Count() > 0)
                {
                    Issues.AddRange(project.ProjectIssues);
                }
            }

            int count = Issues.Count;

            //This is basically the model i return to the view, i assign its properties with values gotten above
            ListOfIssuesViewModel viewModel = new ListOfIssuesViewModel
            {
                Issues = _issueRepo.GetIssues(Issues, pageNumber),
                //The below property is used for pagination
                PageMetaData = new PageMetaData
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = 2,
                    TotalItems = count
                }
            };
            return View(viewModel);
        }

        //This action method is used to get the page that allows you to create a new issue
        public async Task<IActionResult> Create(long id)
        {
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);
            //This is basically the model i return to the view
            IssueViewModel viewModel = ViewIssueFactory.Create(new Issue(), Statuses, Priorities, Members);
            return View("IssueEditor", viewModel);
        }
        
        
        //This action method handles the creation of an issue
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Issue issue)
        {
            //Gets the current user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);

            //Checks if the issue coming in from the user is valid
            if (ModelState.IsValid)
            {
                //Checks if the issue is assigned to someone/a member, if it is assigned to someone, then i get that someone from the database
                //then i assign the issue's member name property to the name of the person assigned to the issue
                if (issue.MemberId != null)
                {
                    Member member = await _membersRepo.GetMemberAsync(issue.MemberId);
                    issue.MemberName = member.UserName;
                }

                //Gets the status and priority assigned to the issue 
                Status statusName = await _statusRepo.FindStatus(issue.StatusId);
                Priority priorityName = await _priorityRepo.FindPriority(issue.PriorityId);

                //Gets the projectId which the issue belongs to from the url parameters
                issue.ProjectId = long.Parse((string)HttpContext.Request.RouteValues["id"]);
                issue.DateCreated = DateTime.Now.Date;
                issue.StatusName = statusName.Name;
                issue.PriorityName = priorityName.Name;
                _issueRepo.Create(issue);
                await _dbContext.SaveChangesAsync(User.Identity.Name, IdUser.Administrator);
                return Redirect("/home/index");
            }
            return View("IssueEditor", ViewIssueFactory.Create(issue, Statuses, Priorities, Members));
        }

        //This action method returns the page that allows you to edit an issue 
        public async Task<IActionResult> Edit(long id)
        {
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            Issue issue = await _issueRepo.GetIssueById(id);
            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);
            IssueViewModel viewModel = ViewIssueFactory.Edit(issue, Statuses, Priorities, Members);
            return View("IssueEditor", viewModel);
        }

        //This action method handles the process of editing an issue
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]Issue issue)
        {
            
            //This gets the person assigned to the issue, if there are any
            Member member = await _membersRepo.GetMemberAsync(issue.MemberId);
            //Gets the current user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            //Gets the current state of the issue that we are trying to edit from the database
            Issue issueDb = await _issueRepo.GetIssueById(issue.IssueId);

            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);

            //Checks if the issue coming in from the user is valid
            if (ModelState.IsValid)
            {
                //Checks if the issue is assigned to someone/a member, if it is assigned to someone, then i get that someone from the database
                //then i update the issue's member name property to the name of the person assigned to the issue
                if (issue.MemberId != null)
                {
                    issueDb.MemberName = member.UserName;
                    issueDb.MemberId = member.MemberID;
                }

                //Checks if the issue coming in has a description, if it has, then update the issue gotten from the database
                if (issue.Decription != null)
                {
                    issueDb.Decription = issue.Decription;
                }

                Status statusName = await _statusRepo.FindStatus(issue.StatusId);
                Priority priorityName = await _priorityRepo.FindPriority(issue.PriorityId);
                issueDb.StatusName = statusName.Name;
                issueDb.PriorityName = priorityName.Name;                
                issueDb.DateClosed = issue.DateClosed;
                issueDb.Title = issue.Title;

                _issueRepo.Update(issueDb);
                await _dbContext.SaveChangesAsync(User.Identity.Name, IdUser.Administrator);
                return Redirect("/home/index");
            }
            return View("IssueEditor", ViewIssueFactory.Edit(issue, Statuses, Priorities, Members));
        }

        //This action method returns the page that allows you delete an issue
        public async Task<IActionResult> Delete(long id)
        {
            IdUser = await UserManager.FindByIdAsync(User.Identity.Name);
            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);
            Issue issue = await _issueRepo.GetIssueById(id);
            IssueViewModel viewModel = ViewIssueFactory.Delete(issue, Statuses, Priorities, Members);
            return View("IssueEditor", viewModel);
        }

        //This action method handles the process of deleting an issue
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]Issue issue)
        {
            //Gets the current user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            _issueRepo.Delete(issue);
            await _dbContext.SaveChangesAsync(User.Identity.Name, IdUser.Administrator);
            return Redirect("/home/index");
        }

        //This action method returns details of an issue
        //This attribute is used to give access to users that are neither an Admin or a Developer 
        [AllowAnonymous]
        public async Task<IActionResult> Details(long id, int pageNumber = 1)
        {
            //Gets the current user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);

            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);

            //Gets an issue including its associated comments and the project the issue is in
            Issue issue = await _issueRepo.GetIssuePlusCommentAndProjectById(id);
            
            //Gets the total count of activities that has been performed within the particular issue
            int count = _auditRepo.GetActivitiesCountPerIssue(IdUser.Administrator, issue.IssueId);

            //Gets all of the activities that has been performed within the particular issue
            Activities = await _auditRepo.GetActivitiesById(issue.IssueId, pageNumber);
            //This converts all the activities into a JSON text
            AuditObject auditObject = JsonConverter.ConvertJsonToDictionary(Activities);
            
            //The below property is used for pagination
            PageMetaData pageMetaData = new PageMetaData 
            { 
                CurrentPage = pageNumber,
                ItemsPerPage = 3,
                TotalItems = count
            };

            IssueViewModel viewModel = ViewIssueFactory.Details(issue, Statuses, Priorities, Members, Activities, auditObject, pageMetaData);
            return View(viewModel);
        }

        //This action method is used for handling when a user post a comment
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Details([FromForm]Issue issue, int pageNumber = 1)
        {
            //Gets the current user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);

            Members = await _membersRepo.FindMembersWithoutTask(IdUser.Administrator);

            //Gets the total count of activities that has been performed within the particular issue
            int count = _auditRepo.GetActivitiesCountPerIssue(IdUser.Administrator, issue.IssueId);

            //Gets all of the activities that has been performed within the particular issue
            Activities = await _auditRepo.GetActivitiesById(issue.IssueId, pageNumber);

            //The below property is used for pagination
            PageMetaData pageMetaData = new PageMetaData
            {
                CurrentPage = pageNumber,
                ItemsPerPage = 3,
                TotalItems = count
            };

            //This converts all the activities into a JSON text
            AuditObject auditObject = JsonConverter.ConvertJsonToDictionary(Activities);

            //Checks if the issue coming in from the user is valid
            if (ModelState.IsValid)
            {
                //Checks if the issue is assigned to someone/a member, if it is assigned to someone, then i get that someone from the database
                //then i update the issue's member name property to the name of the person assigned to the issue
                if (issue.MemberId != null)
                {
                    Member member = await _membersRepo.GetMemberAsync(issue.MemberId);
                    issue.MemberName = member.UserName;
                }

                //This class is used to create a comment made by the user
                Comment comment = new Comment { statement = issue.Comment, IssueId = issue.IssueId, PersonNameComment = IdUser.UserName, 
                    CommentDate = DateTime.Now};

                //Then add the comment to the database
                _commentRepo.Create(comment);
                //This adds the comment to the collection of comments associated with that issue 
                issue.Comments.Add(comment);
                _commentRepo.Save();
                return RedirectToAction(nameof(Details));
            }
            return View("IssueEditor", ViewIssueFactory.Details(issue, Statuses, Priorities, Members, Activities, auditObject, pageMetaData));
        }
    }
}
