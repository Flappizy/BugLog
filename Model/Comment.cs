using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Model
{
    //This is used to model a comment 
    public class Comment
    {
        public long CommentId { get; set; }
        public long IssueId { get; set; }
        public string statement { get; set; }
        public DateTime CommentDate { get; set; }
        public string PersonNameComment { get; set; }
    }
}
