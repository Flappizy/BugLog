using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buglog.Model;
using Buglog.Dto;
using Buglog.Data;
using Buglog.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Buglog.Model.IdentityModels;
using Buglog.Model.ViewModel;
using AutoMapper;
using Buglog.Model.Pagination;

namespace BugLog.Controllers
{
    //This controller handles the management of members within an account
    //The attribute specifies that only a user that is an admin can have access to it
    [Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        public AppDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;
        private IMembersRepo _membersRepo;
        private IIssueRepo _issueRepo;
        private RoleManager<IdentityRole> _roleManager;
        private IEnumerable<Member> members => _dbContext.Members.Include(m => m.Tasks).Where(m => m.User == IdUser.UserName);
        private IEnumerable<Issue> issues => _dbContext.Issues;
        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;
        public ApplicationUser IdUser { get; set; }


        public MemberController(AppDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
             IMembersRepo membersRepo, IMapper mapper, IIssueRepo issueRepo)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _membersRepo = membersRepo;
            _mapper = mapper;
            _issueRepo = issueRepo;
        }

        //This action method is used to show all members that is within an account
        //The attribute on the action method makes it possible for users who are not an admin have access to it
        [AllowAnonymous]
        public async Task<IActionResult> ShowMembers(int pageNumber = 1)
        {
            //Gets the curent user
            IdUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //Gets all the members within the account
            IEnumerable<Member> members = await _membersRepo.GetMembers(IdUser.Administrator, pageNumber);

            //This object represents the view model
            MemberViewModel viewModel = new MemberViewModel
            {
                Members = members,
                AdminRoleVerification = await _userManager.IsInRoleAsync(IdUser, "Admin"),
                
                //The below property is used for pagination
                PageMetaData = new PageMetaData
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = 6,
                    TotalItems = _membersRepo.FindMembersCount(IdUser.Administrator)
                }                
            };

            return View(viewModel);
        }       

        //This action method shows the page that is used to edit a member
        public async Task<IActionResult> Edit(long id)
        {            
            Member member = await _membersRepo.GetMemberAsync(id);
            MemberViewModel viewModel = ViewMemberFactory.Edit(member, Roles, members);
            return View("MemberEditor", viewModel);
        }

        //This action method handles the process of editing a member  
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditMember([FromForm]Member member)
        {
            //Gets the current user
            IdUser = await _userManager.FindByNameAsync(User.Identity.Name);
            
            //Checks if the model object coming from the user is valid
            if (ModelState.IsValid)
            {
                //Sets who invited the member
                member.User = IdUser.UserName;
                _dbContext.Members.Update(member);
                await _dbContext.SaveChangesAsync(User.Identity.Name, IdUser.Administrator);
                return Redirect("/home/index");
            }
            return View("MemberEditor", ViewMemberFactory.Edit(member, Roles, members));
        }


        //This action method returns the page that allows you to delete a member 
        public async Task<IActionResult> Delete(long id)
        {
            Member member = await _dbContext.Members.FindAsync(id);
            MemberViewModel viewModel = ViewMemberFactory.Delete(member, Roles, members);
            return View("MemberEditor", viewModel);
        }
        
        //This action method handles the process of deleting a member
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteMember(long id)
        {
            //Gets the member that will be deleted
            Member member = await _membersRepo.GetMemberAsync(id);
            IdUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //What this does is every assigned to that particular member is set to null, since the member is going to be deleted 
            foreach (Issue issue in issues)
            {
                if (issue.MemberId == member.MemberID)
                {
                    issue.MemberId = null;
                    issue.MemberName = null;
                    _issueRepo.Update(issue);
                }
            }
            //This deletes the member from the member list
            _membersRepo.Delete(member);
            //Gets the member account
            ApplicationUser user = await _userManager.FindByNameAsync(member.UserName);
            //This deletes the member account
            await _userManager.DeleteAsync(user);
            await _dbContext.SaveChangesAsync(User.Identity.Name, IdUser.Administrator);
            return Redirect("/home/index");
        }

        //This action method is used to get details of a particular member
        //This attribute makes sure the action method can be accessed by users that are not Admin
        [AllowAnonymous]
        public async Task<IActionResult> Details(long id)
        {
            Member member = await _dbContext.Members.FindAsync(id);
            MemberViewModel viewModel = new MemberViewModel
            {
                Member = member,
                Issues = await _issueRepo.GetIssueByMemberId(member.MemberID)
            };


            return View("Details", viewModel);
        }
    }
}
