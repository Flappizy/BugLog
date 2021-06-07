using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;
using System.Linq.Expressions;
using Buglog.Model.IdentityModels;

namespace Buglog.Contracts
{
   //This is an interface for the project repo
    public interface IProjectRepo : IRepositoryBase<Project>
    {
        Task<List<Project>> FindProjectIncludeIssues(string user, int pageNumber);
        Task<Project> GetProject(long id);
        Task<List<Project>> FindLatestProjectIncludeIssues(string user);
        int GetProjects(string user);
        Task<List<Project>> GetProjects(string user, int pageNumber);
        Task<List<Project>> GetProjectsWithoutIssue(string user);
        Task<List<Project>> FindProjectIncludeIssues(string user);
    }
}
