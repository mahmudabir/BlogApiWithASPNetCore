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
        private readonly IUnitOfWork _uow;
        public CredentialRepository(ApplicationDbContext db, IUnitOfWork uow) : base(db)
        {
            _db = db;
            _uow = uow;
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
