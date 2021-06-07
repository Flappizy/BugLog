using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Buglog.Data;

namespace Buglog.Model
{
    public class SeeData
    {
        public static void SeedDataBase(AppDbContext dataContext)
        {
            dataContext.Database.Migrate();

            if (dataContext.Issues.Count() == 0 && dataContext.Priority.Count() == 0)
            {
                Status notStarted = new Status { Name = "Not Started" };
                Status inProgress = new Status { Name = "In Progress" };
                Status closed = new Status { Name = "Closed" };
                dataContext.Status.AddRange(notStarted, inProgress, closed);
                dataContext.SaveChanges();

                Priority minor = new Priority { Name = "Minor" };
                Priority critical = new Priority { Name = "Critical" };
                Priority major = new Priority { Name = "Major" };
                dataContext.Priority.AddRange(minor, critical, major);
                dataContext.SaveChanges();

            }
        }
    }
}
