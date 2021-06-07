using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buglog.Services;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Buglog.Contracts;
using Buglog.Data;
using Buglog.Model.ViewModel;
using Buglog.Model;
using Buglog.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BugLog.Controllers
{
    //This controller handles members invitation through mail and members registration an login 
    public class MailController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;     
        private IMailService _mailService;
        private AppDbContext _dbContext;
        private SignInManager<ApplicationUser> _signInManager;        
        private IDistributedCache _cache;
        private IMembersRepo _membersRepo;
        private UserManager<ApplicationUser> _userManager;
        private IProjectRepo _projectRepo;
        private IAuditRepo _auditRepo;
        private ApplicationUser _user;
        private IIssueRepo _issueRepo;


        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public List<Audit> Activities { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();


        //This method is used to serialize/convert a member object into a JSON string
        public string SerializeObject(Member member) => JsonSerializer.Serialize(member);

        //This method is used to deserialize/convert a JSON string into a member object
        public Member DeserializeObjectMember(string json) => JsonSerializer.Deserialize<Member>(json);


        public MailController(RoleManager<IdentityRole> roleManager, IMailService mailService, AppDbContext dbContext, 
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, 
            IDistributedCache cache, IMembersRepo membersRepo, IProjectRepo projectRepo, IAuditRepo auditRepo, IIssueRepo issueRepo)
        {
            _roleManager = roleManager;
            _mailService = mailService;
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _cache = cache;
            _membersRepo = membersRepo;
            _auditRepo = auditRepo;
            _projectRepo = projectRepo;
            _issueRepo = issueRepo;
        }

        //This method shows the page where you can invite a member
        public IActionResult Invite()
        {
            MailInfo mailInfo = new MailInfo
            {
                Roles = _roleManager.Roles
            };
            ViewBag.Message = TempData["Message"];
            return View(mailInfo);
        }

        //This action method handles the sending an invite
        [HttpPost]
        public async Task<ActionResult> SendInvite([FromForm]MailInfo mailInfo)
        {
            //What i did here is setting the who invited(inviter) the invitee
            mailInfo.User = User.Identity.Name;
            mailInfo.Roles = _roleManager.Roles;
            

            string cacheKeyRole = "memberRole";
            string memberRole = mailInfo.AssignedRole;
            string cacheKeyUser = "memberUser";
            string memberUser = mailInfo.User;

            //I cached the memberRole value so that i can use it from one request to another, i did this because i used the value
            //for a member registration and login
            await _cache.SetStringAsync(cacheKeyRole, memberRole, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
            });
            
            //I cached the inviter(memberUser) value so that i can use it from one request to another, i did this because i used the value
            //for a member registration and login
            await _cache.SetStringAsync(cacheKeyUser, memberUser, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
            });

            //Checks if the incoming model object is valid, if it is then send an invite mail
            if (ModelState.IsValid)
            {
                await _mailService.SendInviteEmailAsync(mailInfo);
                TempData["Message"] = "You have successfully sent Invite";
            }
            
            return RedirectToAction("Invite");
        }

        //This action method shows the page where a member can register
        public IActionResult AcceptInvite()
        {
            MemberLoginModel memberLoginInfo = new MemberLoginModel();
            return View(memberLoginInfo);
        }

        //This action method handles the process of a member registration, it creates a memebr object and also a acccont/user for 
        //invited member
        [HttpPost]
        public async Task<IActionResult> AcceptInvite([FromForm]MemberLoginModel memberLoginInfo)
        {
            //Create a new member object
            Member member = new Member();
            //Sets who invited the member
            member.User = await _cache.GetStringAsync("memberUser");
            //Sets the role given to the invited member
            member.AssignedRole = await _cache.GetStringAsync("memberRole");
            member.UserName = memberLoginInfo.UserName;
            member.Email = memberLoginInfo.Email;
            //TempData["memberEmail"] = memberLoginInfo.Email;

            //This is used to create an account/user for the incoming member
            ApplicationUser user = new ApplicationUser 
            { 
                UserName = memberLoginInfo.UserName, 
                Email = memberLoginInfo.Email,
                //The below property specifies who invited the user
                Administrator = member.User
            };
            IdentityResult result = await _userManager.CreateAsync(user, memberLoginInfo.Password);
            
            //Checks if the model object coming in from the user is valid and if an account was created for the member successfully
            //if it is true then a member is created
            if (ModelState.IsValid && result.Succeeded)
            {
                _membersRepo.Create(member);
                await _userManager.AddToRoleAsync(user, member.AssignedRole);
                await _dbContext.SaveChangesAsync(member.User, member.User);
                //TempData["MemberId"] = member.MemberID.ToString();
                return RedirectToAction(nameof(InviteeLogin));
            }
            return View(memberLoginInfo);
        }

        //This action method shows the page that allows an invitee to login
        public IActionResult InviteeLogin()
        {
            MemberLoginModel memberLoginInfo = new MemberLoginModel();
            return View(memberLoginInfo);
        }

        
        //This action method handles the process of an invitee login, if successful it shows the homepage
        [HttpPost]
        [ActionName("InviteeLogin")]
        public async Task<IActionResult> Login([FromForm]MemberLoginModel memberLoginInfo)
        {
            //This handles the process of sigining in
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(memberLoginInfo.UserName, memberLoginInfo.Password, false, false);
            
            //Checks if the process of sigining in is successful
            if (result.Succeeded)
            {
                //Gets the member from the members repository
                Member member = await _membersRepo.GetMemberByUser(memberLoginInfo.UserName);
                
                //Then check if the member/invitee is an admin or a developer, because i will be using this to determine what a member has access
                //to within their account
                bool adminOrDevRoleVerification = member.AssignedRole == "Developer" || member.AssignedRole == "Admin";
                
                //Also check if the member/invitee is an admin because i will be using this to determine what a member has access
                //to within their account
                bool adminRoleVerification = member.AssignedRole == "Admin";
                
                //Gets the latest projects added by the inviter within the account
                Projects = await _projectRepo.FindLatestProjectIncludeIssues(member.User);
                
                //Gets the latest members added by the inviter within the account
                Members = await _membersRepo.FindLatestMembers(member.User);

                //Gets the latest activities that has been carried out by the inviter and invitee 
                Activities = await _auditRepo.GetLatestActivities(member.User); 
                
                //Gets all the issues within the projects 
                foreach (Project project in Projects)
                {
                    if (project.ProjectIssues.Count() > 0)
                    {
                        Issues.AddRange(project.ProjectIssues);
                    }
                }

                //This object represents the view model returned to the user
                AppViewModel viewModel = new AppViewModel
                {
                    Projects = Projects,
                    Issues = _issueRepo.GetLatestIssues(Issues),
                    Members = Members,
                    AdminOrDevRoleVerification = adminOrDevRoleVerification,
                    AdminRoleVerification = adminRoleVerification,
                    Activities = Activities
                };
                return View("Index", viewModel);
            }

            TempData["Message"] = "Invalid Username or Password";
            return View(memberLoginInfo);
        }
    }
}
