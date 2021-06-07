using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;
using Buglog.Model.IdentityModels;

namespace Buglog.Contracts
{
    //This is an interface for the audit repo
    public interface IAuditRepo
    {
        Task<List<Audit>> GetActivities(string user);
        Task<List<Audit>> GetLatestActivities(string user);
        Task<List<Audit>> GetActivities(string admin, int pageNumber);
        int GetActivitiesCount(string admin);
        Task<List<Audit>> GetActivitiesById(long entityPrimaryKey, int pageNumber);
        int GetActivitiesCountPerIssue(string admin, long issueId);
    }
}
