using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Buglog.Validation;


namespace Buglog.Model
{
    //This class is used to model an issue 
    [DateClosedValidStatus(StatusId = 3)]
    public class Issue
    {
        public Issue()
        {
        }

        public long IssueId { get; set; }
        
        [Required(ErrorMessage ="Issue requires a Title")]
        public string Title { get; set; }
        
        public Project Project { get; set; }
        public long ProjectId { get; set; }

        public string Decription { get; set; }
        
        public Status Status { get; set; }
        [Required(ErrorMessage = "Issue requires a Status")]
        public long? StatusId { get; set; }
        public string StatusName { get; set; }

        public Priority Priority { get; set; }
        [Required(ErrorMessage = "Issue requires a priority")]
        public long? PriorityId { get; set; }
        public string PriorityName { get; set; }

        public Member Member { get; set; }
        public long? MemberId { get; set; }
        public string MemberName { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string Comment { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}
