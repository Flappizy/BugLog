using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Buglog.Data;

namespace Buglog.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext DbContext { get; set; }

        public RepositoryBase(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.DbContext.Set<T>().AsNoTracking();
        }

        public void Create(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }
    }
}
