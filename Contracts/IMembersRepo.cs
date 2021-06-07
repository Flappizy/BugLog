using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model.IdentityModels;
using Buglog.Model;

namespace Buglog.Contracts
{
    //This is an interface for the member repo
    public interface IMembersRepo : IRepositoryBase<Member>
    {
        Task<List<Member>> FindMembers(string user);
        Task<Member> GetMemberAsync(long? id);
        Task<Member> GetMemberByUser(string user);
        Task<List<Member>> FindMembersWithoutTask();
        Task<List<Member>> FindLatestMembers(string user);
        int FindMembersCount(string user);
        Task<List<Member>> GetMembers(string user, int memberPage);
        Task<Member> GetMember(string userName);
        Task<List<Member>> FindMembersWithoutTask(string admin);
    }
}
