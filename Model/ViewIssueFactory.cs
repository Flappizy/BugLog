using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model.ViewModel;
using Buglog.Model.Pagination;

namespace Buglog.Model
{
    public class ViewIssueFactory
    {
        public ViewIssueFactory()
        {

        }

        public static IssueViewModel Create(Issue issue, IEnumerable<Status> statuses, IEnumerable<Priority> priorities, IEnumerable<Member> members)
        {
            return new IssueViewModel
            {
                Issue = issue,
                Statuses = statuses,
                Priorities = priorities,
                Members = members,
                Action = "Create"       
            };
        }

        public static IssueViewModel Edit(Issue issue, IEnumerable<Status> statuses, IEnumerable<Priority> priorities, IEnumerable<Member> members)
        {
            return new IssueViewModel
            {
                Issue = issue,
                Statuses = statuses,
                Priorities = priorities,
                Members = members,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static IssueViewModel Delete(Issue issue, IEnumerable<Status> statuses, IEnumerable<Priority> priorities, IEnumerable<Member> members)
        {
            return new IssueViewModel
            {
                Issue = issue,
                Statuses = statuses,
                Priorities = priorities,
                Members = members,
                ReadOnly = true,
                Theme = "danger",
                Action = "Delete"
            };
        }

        public static IssueViewModel Details(Issue issue, IEnumerable<Status> statuses, IEnumerable<Priority> priorities, 
            IEnumerable<Member> members, List<Audit> activities, AuditObject auditObject, PageMetaData pageMetaData)
        {
            return new IssueViewModel
            {
                Issue = issue,
                Statuses = statuses,
                Priorities = priorities,
                Activities = activities,
                Members = members,
                AuditObject = auditObject,
                ReadOnly = true,
                PageMetaData = pageMetaData

            };
        }
    }
}
