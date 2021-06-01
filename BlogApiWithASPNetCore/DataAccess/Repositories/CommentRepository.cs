using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;

using Microsoft.Extensions.Hosting;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UnitOfWork _uow;

        public CommentRepository(ApplicationDbContext db, UnitOfWork uow) : base(db)
        {
            _db = db;
            _uow = uow;
        }

        public List<Comment> GetAllCommentsByPost(int pid)
        {
            return _db.Comments.Where(c => c.PostId == pid).ToList();
        }

        public Comment GetPostCommentByID(int pid, int cid)
        {
            return _db.Comments.Where(c => c.PostId == pid && c.Id == cid).FirstOrDefault();
        }

        public void Update(Comment comment)
        {
            var objFromDb = _db.Comments.FirstOrDefault(c => c.Id == comment.Id);
            if (objFromDb != null)
            {
                objFromDb.Content = comment.Content;
                _db.SaveChanges();
            }
        }
    }
}
