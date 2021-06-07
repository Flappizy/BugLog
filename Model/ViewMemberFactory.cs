using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Buglog.Model.ViewModel;
using Buglog.Model;

namespace Buglog.Model
{
    public static class ViewMemberFactory
    {
        public static MemberViewModel Edit(Member member, IEnumerable<IdentityRole> roles, IEnumerable<Member> members)
        {
            return new MemberViewModel { Member = member, Roles = roles, Members = members, Theme = "warning", Action = "Edit" };
        }

        public static MemberViewModel Delete(Member member, IEnumerable<IdentityRole> roles, IEnumerable<Member> members)
        {
            return new MemberViewModel 
            { 
                Member = member, 
                Roles = roles, 
                Members = members, 
                Theme = "danger",
                Action = "Delete",
                ReadOnly = true 
            };
        }

        public static MemberViewModel Details(Member member, IEnumerable<IdentityRole> roles, IEnumerable<Member> members, IEnumerable<Issue> issues)
        {
            return new MemberViewModel { Member = member, Roles = roles, Members = members, Issues = issues, ReadOnly = true};
        }
    }
}
