using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Buglog.Model;
using Buglog.Data;
using Buglog.Model.Pagination;

namespace Buglog.Model
{
    public class AppViewModel
    {
        public AppViewModel()
        {
        }


        public AppDbContext DataContext { get; set; }
        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();
        public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
        public IEnumerable<Member> Members { get; set; } = Enumerable.Empty<Member>();
        public IEnumerable<Audit> Activities { get; set; } = Enumerable.Empty<Audit>();
        public bool AdminOrDevRoleVerification { get; set; }
        public bool AdminRoleVerification { get; set; }
        public PageMetaData PageMetaData { get; set; }

    }
}
