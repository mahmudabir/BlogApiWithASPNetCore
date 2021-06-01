using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db, this);
            Post = new PostRepository(_db, this);
            Comment = new CommentRepository(_db, this);
            Credential = new CredentialRepository(_db, this);
            Role = new RoleRepository(_db, this);
        }

        public IUserRepository User { get; set; }
        public IPostRepository Post { get; set; }
        public ICommentRepository Comment { get; set; }
        public ICredentialRepository Credential { get; set; }
        public IRoleRepository Role { get; set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
