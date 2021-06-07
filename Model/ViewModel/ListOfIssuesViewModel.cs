using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model.Pagination;

namespace Buglog.Model.ViewModel
{
    public class ListOfIssuesViewModel
    {
        public PageMetaData PageMetaData { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
