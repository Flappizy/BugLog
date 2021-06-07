using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Data;
using Buglog.Model;
using Buglog.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Buglog.Contracts;

namespace Buglog.Repository
{
    public class AuditRepo : IAuditRepo
    {
        private AppDbContext _dbContext;
        private int pageSize = 3;

        public AuditRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Audit>> GetLatestActivities(string admin)
        {
            int activityCount = _dbContext.AuditLogs.Where(a => a.Administrator == admin).Count();          
            int skip = activityCount < 5 ? activityCount : activityCount - 4;
            int count = activityCount > 4 ? 4 : activityCount;

            if (activityCount < 5)
            {
                return await _dbContext.AuditLogs.Where(a => a.Administrator == admin).ToListAsync();
            }

            return await _dbContext.AuditLogs.Where(a => a.Administrator == admin).Skip(skip)
                .Take(count).ToListAsync();
        }

        public async Task<List<Audit>> GetActivities(string admin)
        {
            return await _dbContext.AuditLogs.Where(a => a.Administrator.Equals(admin) && a.EntityTableName.Equals("Issue")).ToListAsync();
        }

        public async Task<List<Audit>> GetActivitiesById(long entityPrimaryKey, int pageNumber)
        {
            return await _dbContext.AuditLogs.Where(a => a.EntityPrimaryKey.Equals(entityPrimaryKey) 
            && a.EntityTableName.Equals("Issue")).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public int GetActivitiesCount(string admin)
        {
            return _dbContext.AuditLogs.Where(a => a.Administrator.Equals(admin)).Count();
        }

        public int GetActivitiesCountPerIssue(string admin, long issueId)
        {
            return _dbContext.AuditLogs.Where(a => a.Administrator.Equals(admin) && a.EntityPrimaryKey.Equals(issueId)).Count();
        }

        public async Task<List<Audit>> GetActivities(string admin, int pageNumber)
        {
            return await _dbContext.AuditLogs.Where(a => a.Administrator.Equals(admin))
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
