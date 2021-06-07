using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Contracts;
using Buglog.Data;
using Buglog.Model;

namespace Buglog.Repository
{
    public class CommentRepo : RepositoryBase<Comment>, ICommentRepo
    {
        public CommentRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
