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
using AutoMapper;
using Buglog.Dto;
using Buglog.Model.Pagination;
using Buglog.Data;
using Microsoft.AspNetCore.Authorization;
using Buglog.Model.IdentityModels;

namespace BugLog.Controllers
{
    //The attribute specifies that only a user that is an admin can have access to it
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private IProjectRepo _projectRepo;
        private IMembersRepo _memberRepo;
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Issue> Issues { get; set; } = new List<Issue>();
        public List<Member> Members { get; set; } = new List<Member>();
        public UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationUser IdUser { get; set; }
        private AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public ProjectController(IProjectRepo projectRepo, UserManager<ApplicationUser> userManager, IMembersRepo membersRepo, 
            IMapper mapper, AppDbContext dbContext)
        {
            _projectRepo = projectRepo;
            _memberRepo = membersRepo;
            _mapper = mapper;
            _dbContext = dbContext;
            UserManager = userManager;
        }

        //This action method displays all the projects that is associated with an account
        //The attribute on the action method makes it possible for users who are not an admin have access to it
        [AllowAnonymous]
        public async Task<IActionResult> ShowProjectsAsync(int projectPage = 1)
        {
            //Gets user
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            
            //Gets all the projects associated within an account
            Projects = await _projectRepo.GetProjects(IdUser.Administrator, projectPage);
           
            //This is the view model returned to the users
            AppViewModel viewModel = new AppViewModel
            {
                Projects = Projects,
                AdminRoleVerification = await UserManager.IsInRoleAsync(IdUser, "Admin"),
                AdminOrDevRoleVerification = await UserManager.IsInRoleAsync(IdUser, "Admin") 
                || await UserManager.IsInRoleAsync(IdUser, "Developer"),

                //The below property is used for pagination
                PageMetaData = new PageMetaData 
                { 
                    CurrentPage = projectPage,
                    ItemsPerPage = 2,
                    TotalItems = _projectRepo.GetProjects(IdUser.Administrator)                  
                }

            };
            return View(viewModel);
        }

        //This action method is used to get the details of a project
        //The attribute on the action method makes it possible for users who are not an admin have access to it
        [AllowAnonymous]
        public async Task<IActionResult> ShowProjectDetails(long id)
        {
            Project project = await _projectRepo.GetProject(id);
            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
            return View(projectDto);
        }

        
        //This action method is used to get the page that allows users to delete a project
        public async Task<IActionResult> DeleteProject(long id)
        {
            Project project = await _projectRepo.GetProject(id);
            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
            return View(projectDto);
        }

        //This action method allows users to delete a project
        [HttpPost]
        [ActionName("DeleteProject")]
        public async Task<IActionResult> Delete(long id)
        {
            IdUser = await UserManager.FindByNameAsync(User.Identity.Name);
            Project project = await _projectRepo.GetProject(id);
            _projectRepo.Delete(project);
            await _dbContext.SaveChangesAsync(User.Identity.Name, IdUser.Administrator);
            return Redirect("/home/index");
        }
    }
}
