using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UnitOfWork _uow;

        public PostRepository(ApplicationDbContext db, UnitOfWork uow) : base(db)
        {
            _db = db;
            _uow = uow;
        }

        public List<Post> PostSearch(string search)
        {
            return _db.Posts
                .Where(p =>
                p.Title.Contains(search) ||
                p.Content.Contains(search) ||
                p.User.Username.Contains(search)).ToList();
        }

        public void Update(Post post)
        {
            var objFromDb = _db.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = post.Title;
                objFromDb.Content = post.Content;
                _db.SaveChanges();
            }
        }
    }
}
