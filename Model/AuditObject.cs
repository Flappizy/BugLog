using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Model
{
    //This class is used to repesent every changes made to an entity in a sting format
    public class AuditObject : Dictionary<string, string>
    {
        public Dictionary<string, object> OldValue { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValue { get; set; } = new Dictionary<string, object>();
    }
}
