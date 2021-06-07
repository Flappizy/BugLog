using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Buglog.Model.Infrastructure
{
    //This class is used to convert Audit class to Json 
    public class JsonConverter
    {

        public static AuditObject ConvertJsonToDictionary(List<Audit> audits)
        {
            Dictionary<string, object> jsonOldKeyValue = new Dictionary<string, object>();
            Dictionary<string, object> jsonNewKeyValue = new Dictionary<string, object>();

            foreach (Audit audit in audits)
            {
                jsonOldKeyValue = JsonSerializer.Deserialize<Dictionary<string, object>>(audit.OldValues);
                jsonNewKeyValue = JsonSerializer.Deserialize<Dictionary<string, object>>(audit.NewValues);
            }
            AuditObject auditObject = new AuditObject { OldValue = jsonOldKeyValue, NewValue = jsonNewKeyValue };
            return auditObject;
        }
    }
}
