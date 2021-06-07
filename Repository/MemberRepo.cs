using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;
using Buglog.Contracts;
using Buglog.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Buglog.Data;

namespace Buglog.Repository
{
    public class MemberRepo : RepositoryBase<Member>, IMembersRepo
    {
        public MemberRepo(AppDbContext dbContext) : base(dbContext)
        {                
        }

        private int _pageSize = 6;

        public async Task<List<Member>> FindLatestMembers(string user)
        {
            int memberCount = DbContext.Members.Where(m => m.User == user).Count();
            int skip = memberCount < 5 ? memberCount : memberCount - 4;
            int count = memberCount > 4 ? 4 : memberCount;

            if (memberCount < 5)
            {
                return await DbContext.Members.Include(m => m.Tasks).Where(m => m.User == user).ToListAsync();
            }

            return await DbContext.Members.Include(m => m.Tasks).Where(m => m.User == user).Skip(skip).Take(count).ToListAsync();
        }

        public async Task<List<Member>> FindMembers(string user)
        {
            return await DbContext.Members.Include(m => m.Tasks).Where(m => m.User == user).ToListAsync();
        }

        public async Task<List<Member>> GetMembers(string user, int memberPage)
        {
            return await DbContext.Members.Where(m => m.User == user)
                .Skip((memberPage - 1) * _pageSize).Take(_pageSize).ToListAsync();
        }

        public async Task<List<Member>> FindMembersWithoutTask()
        {
            return await DbContext.Members.Where(m => m.User == m.User).ToListAsync();
        }

        public async Task<List<Member>> FindMembersWithoutTask(string admin)
        {
            return await DbContext.Members.Where(m => m.User == admin).ToListAsync();
        }

        public int FindMembersCount(string user)
        {
            return DbContext.Members.Where(m => m.User == user).Count();
        }

        public async Task<Member> GetMemberAsync(long? id)
        {
           return await DbContext.Members.Include(m => m.Tasks).FirstOrDefaultAsync(m => m.MemberID == id);
        }

        public async Task<Member> GetMemberByUser(string userName)
        {
           return await DbContext.Members.Where(m => m.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<Member> GetMember(string userName)
        {
            return await DbContext.Members.Where(m => m.User == userName).FirstOrDefaultAsync();
        }

    }
}
