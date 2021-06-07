using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Buglog.Model;
using Buglog.Enums;

namespace Buglog.Data
{
    //This class inherits directly from the dbcontext class, this class is used to intercept evey changes that has  taken place within an 
    //entity, and it is used track users activities within an account
    public class AuditAppDbContext : DbContext
    {
        public AuditAppDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Audit> AuditLogs { get; set; }

        //This  method is redefined by this class and before saving an entity, it is used to
        //get some information about the entity
        public virtual async Task<int> SaveChangesAsync(string userName, string administrator)
        {
            BeforeSavingChanges(userName, administrator);
            int result = await base.SaveChangesAsync();
            return result;

        }

        //This method is used to get information before the entity is being saved
        public void BeforeSavingChanges(string userName, string administrator)
        {
            //This is used to track any changes within an entity and detect any changes that has taken place
            ChangeTracker.DetectChanges();

            //This object is used to save every activity that has taken place
            List<AuditEntry> auditEntries = new List<AuditEntry>();

            //This is used to get every entity within the database
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Unchanged || entry.State == EntityState.Detached)
                {
                    continue;
                }
                AuditEntry auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserName = userName;
                auditEntry.Administrator = administrator;
                auditEntries.Add(auditEntry);
                //This is used to get every property of an entity
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.EntityPrimaryKey = property.CurrentValue;
                        continue;
                    }
                    else if (propertyName == "Title" || propertyName == "ProjectName" || propertyName == "UserName")
                    {
                        auditEntry.EntityName = property.CurrentValue;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    else if (propertyName == "Comment" || property.CurrentValue == null)
                    {
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            auditEntry.Operation = AuditType.Deleted;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            auditEntry.Operation = AuditType.Updated;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.ChangedColumns.Add(propertyName);
                            break;
                        case EntityState.Added:
                            auditEntry.Operation = AuditType.Created;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (AuditEntry auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }
    }
}
