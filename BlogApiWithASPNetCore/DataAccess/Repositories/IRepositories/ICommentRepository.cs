using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public void Update(Comment comment);
        public List<Comment> GetAllCommentsByPost(int pid);
        public Comment GetPostCommentByID(int pid, int cid);
    }
}
