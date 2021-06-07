using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Buglog.Model.Pagination;

namespace Buglog.Model.ViewModel
{
    public class MemberViewModel
    {
        public MemberViewModel()
        {
        }

        public IEnumerable<IdentityRole> Roles { get; set; }
        public Member Member { get; set; }
        public string Action { get; set; }
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool AdminRoleVerification { get; set; }
        public IEnumerable<Member> Members { get; set; } = Enumerable.Empty<Member>();
        public PageMetaData PageMetaData { get; set; }
        public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
    }
}
