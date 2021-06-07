using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buglog.Model.ViewModel
{
    public class IssueViewModel
    {
        public IssueViewModel()
        {

        }
        public Issue Issue { get; set; }
        public string Action { get; set; }
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public IEnumerable<Member> Members { get; set; } = Enumerable.Empty<Member>();
        public IEnumerable<Status> Statuses { get; set; } = Enumerable.Empty<Status>();
        public IEnumerable<Priority> Priorities { get; set; } = Enumerable.Empty<Priority>();
        public List<Audit> Activities { get; set; } = new List<Audit>();
        public AuditObject AuditObject { get; set; } = new AuditObject();
        public PageMetaData PageMetaData { get; set; }
    }
}
