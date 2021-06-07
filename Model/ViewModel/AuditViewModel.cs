using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model.Pagination;

namespace Buglog.Model.ViewModel
{
    public class AuditViewModel
    {
        public List<Audit> Audits { get; set; }
        public PageMetaData PageMetaData { get; set; }
        public AuditObject AuditObject { get; set; } = new AuditObject();
    }
}
