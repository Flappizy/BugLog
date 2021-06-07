using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Model
{
    //This class is used to model a priority
    public class Priority
    {
        public string Name { get; set; }
        public long PriorityId { get; set; }
        public IEnumerable<Issue> Issues { get; set; }
    }
}
