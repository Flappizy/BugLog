using System;
using System.Collections.Generic;
using System.Linq;
using Buglog.Model;
using System.Threading.Tasks;
using Buglog.Model.Pagination;

namespace Buglog.Dto
{
    public class MemberDto
    {
        public long MemberID { get; set; }
        public string User { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AssignedRole { get; set; }
        public List<Issue> Tasks { get; set; }
        public PageMetaData PageMetaData { get; set; }
    }
}
