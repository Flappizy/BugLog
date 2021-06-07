using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;

namespace Buglog.Contracts
{
    //This is an interface for the comment repo 
    public interface ICommentRepo : IRepositoryBase<Comment>
    {

    }
}
