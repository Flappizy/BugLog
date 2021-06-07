using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Model
{
    //This class is used to represent an activity
    public class Audit
    {
        public long AuditId { get; set; }
        public string EntityTableName { get; set; }
        public string Operation { get; set; }
        public string EntityName { get; set; }
        public long EntityPrimaryKey { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string ChangedColumns { get; set; }
        public string UserName { get; set; }
        public string Administrator { get; set; }
        public DateTime Date { get; set; }    
    }
}
