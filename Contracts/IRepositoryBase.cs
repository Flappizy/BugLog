using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Buglog.Contracts
{
    //This is the base interface for all repository, it defines the basic methods that each repo should support
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();    
    }
}
