using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Contracts;
using Buglog.Data;
using Buglog.Model;

namespace Buglog.Repository
{
    public class PriorityRepo : IPriorityRepo
    {
        private AppDbContext _dbContext;

        public PriorityRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Priority> FindPriority(long? id)
        {
            return await _dbContext.Priority.FindAsync(id);
        }
    }
}
