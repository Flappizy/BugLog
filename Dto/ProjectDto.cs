using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Buglog.Model;

namespace Buglog.Dto
{
    public class ProjectDto
    {
        public string ProjectName { get; set; }
        public long ProjectId { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
        public List<Issue> ProjectIssues { get; set; }
    }
}
