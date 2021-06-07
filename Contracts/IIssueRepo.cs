using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;

namespace Buglog.Contracts
{
    //This is an interface for the issue repo
    public interface IIssueRepo : IRepositoryBase<Issue>
    {
        Task<Issue> GetIssueById(long id);
        Task<Issue> GetIssuePlusCommentAndProjectById(long id);
        List<Issue> GetLatestIssues(List<Issue> issues);
        List<Issue> GetIssues(List<Issue> issues, int pageNumber);
        Task<IEnumerable<Issue>> GetIssueByMemberId(long memberId);
    }
}
