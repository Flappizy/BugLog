using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;

namespace Buglog.Contracts
{
    //This is an interface for the status repo
    public interface IStatusRepo
    {
        Task<Status> FindStatus(long? id);
    }
}
