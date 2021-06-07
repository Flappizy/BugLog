using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Contracts;
using Buglog.Data;
using Buglog.Model;

namespace Buglog.Repository
{
    public class StatusRepo : IStatusRepo
    {
        private AppDbContext _dbContext;
        
        public StatusRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Status> FindStatus(long? id)
        {
            return await _dbContext.Status.FindAsync(id);
        }
    }
}
