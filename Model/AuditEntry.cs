using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Buglog.Model
{
    //This class is an activity dto
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry; 
        }

        public EntityEntry Entry { get; set; }
        public object EntityPrimaryKey { get; set; }
        public object EntityName { get; set; }
        public AuditType Operation { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> OldValues { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; set; } = new Dictionary<string, object>();
        public List<string> ChangedColumns { get; set; } = new List<string>();
        public string UserName { get; set; }
        public string Administrator { get; set; }

        public Audit ToAudit()
        {
            Audit audit = new Audit
            {
                EntityPrimaryKey = long.Parse(JsonConvert.SerializeObject(EntityPrimaryKey)),
                UserName = UserName,
                EntityTableName = TableName,
                EntityName = EntityName.ToString(),
                Date = DateTime.Now,
                Administrator = Administrator,
                Operation = Operation.ToString(),
                OldValues = JsonConvert.SerializeObject(OldValues),
                NewValues = JsonConvert.SerializeObject(NewValues),
                ChangedColumns = JsonConvert.SerializeObject(ChangedColumns)
            };
            return audit;           
        }

    }
}
