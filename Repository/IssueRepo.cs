using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;
using Buglog.Model.IdentityModels;
using Buglog.Data;
using Buglog.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Buglog.Repository
{
    public class IssueRepo : RepositoryBase<Issue>, IIssueRepo
    {
        public IssueRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        private int _pageSize = 2;

        //This method is used to get the four latest issues
        public List<Issue> GetLatestIssues(List<Issue> issues)
        {
            int issueCount = issues.Count();
            int skip = issueCount < 5 ? issueCount : (issueCount - 4);
            int count = issueCount > 4 ? 4 : issueCount;

            if (issueCount < 5)
            {
                return issues;
            }

            return issues.Skip(skip).Take(count).ToList();
        }

        public List<Issue> GetIssues(List<Issue> issues, int pageNumber)
        {
            return issues.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();
        }

        public async Task<Issue> GetIssueById(long id)
        {
            return await DbContext.Issues.FindAsync(id);
        }

        public async Task<Issue> GetIssuePlusCommentAndProjectById(long id)
        {
            return await DbContext.Issues.Include(i => i.Project).Include(i => i.Comments).FirstOrDefaultAsync(i => i.IssueId == id);
        }

        public async Task<IEnumerable<Issue>> GetIssueByMemberId(long memberId)
        {
            return await DbContext.Issues.Where(i => i.MemberId == memberId).ToListAsync();
        }
    }
}
