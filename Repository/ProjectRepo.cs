using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Contracts;
using Buglog.Model;
using Buglog.Model.IdentityModels;
using Buglog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Buglog.Repository
{
    public class ProjectRepo : RepositoryBase<Project>, IProjectRepo
    {
        public ProjectRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public int PageSize = 2;

        public async Task<List<Project>> FindProjectIncludeIssues(string user, int projectPage = 1)
        {
            return await DbContext.Projects.Include(p => p.ProjectIssues).Where(p => p.User == user)
                .Skip((projectPage - 1) * PageSize).Take(PageSize).ToListAsync();
        }

        public async Task<List<Project>> FindProjectIncludeIssues(string user)
        {
            return await DbContext.Projects.Include(p => p.ProjectIssues).Where(p => p.User == user).ToListAsync();
        }

        public int GetProjects(string user)
        {
            return DbContext.Projects.Where(p => p.User == user).Count();
        }

        public async Task<List<Project>> GetProjectsWithoutIssue(string user)
        {
            return await DbContext.Projects.Where(p => p.User == user).ToListAsync();
        }

        public async Task<List<Project>> GetProjects(string user, int projectPage = 1)
        {
            return await DbContext.Projects.Where(p => p.User == user).OrderBy(p => p.ProjectId).Skip((projectPage - 1) * PageSize).
                Take(PageSize).ToListAsync();
        }

        public async Task<List<Project>> FindLatestProjectIncludeIssues(string user)
        {
            //This checks if the number of projects in the database is greater than 4, if so, let the count be four, if not just return the count
            //of elements within the table
            int projectCount = DbContext.Projects.Where(p => p.User == user).Count();

            int skip = projectCount < 5 ? projectCount : (projectCount - 4);
            int count = projectCount > 4 ? 4 : projectCount;

            if (projectCount < 5)
            {
                return await DbContext.Projects.Include(p => p.ProjectIssues).Where(p => p.User.Equals(user)).ToListAsync();
            }

            return await DbContext.Projects.Include(p => p.ProjectIssues).Where(p => p.User.Equals(user)).Skip(skip)
                .Take(count).ToListAsync();
        }

        public async Task<Project> GetProject(long id)
        {
            return await DbContext.Projects.Include(p => p.ProjectIssues).FirstOrDefaultAsync(p => p.ProjectId == id);
        }
    }
}
