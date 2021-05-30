using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class CredentialRepository : Repository<Credential>, ICredentialRepository
    {
        private readonly ApplicationDbContext _db;
        public CredentialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Credential credential)
        {
            var objFromDb = _db.Credentials.FirstOrDefault(u => u.Id == credential.Id);
            if (objFromDb != null)
            {
                objFromDb.Password = credential.Password;
                _db.SaveChanges();
            }
        }
    }
}
