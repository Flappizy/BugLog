using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Buglog.Model
{
    //This class is used to model a project
    public class Project
    {
        public Project()
        {
         
        }

        [Required]
        public string ProjectName { get; set; }
        public long ProjectId { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
        public List<Issue> ProjectIssues { get; set; } = new List<Issue>();
    }
}
