using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Model
{
    //This class is used to model status
    public class Status
    {
        public string Name { get; set; }
        public long StatusId { get; set; }
        public IEnumerable<Issue> Issues { get; set; }
    }
}
