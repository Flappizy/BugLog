using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model;

namespace Buglog.Contracts
{
    //This is an interface for the priority repo
    public interface IPriorityRepo
    {
        Task<Priority> FindPriority(long? id);
    }
}
