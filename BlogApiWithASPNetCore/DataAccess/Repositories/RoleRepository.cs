using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;
using BlogApiWithASPNetCore.Models.ViewModels;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _uow;
        public RoleRepository(ApplicationDbContext db, IUnitOfWork uow) : base(db)
        {
            _db = db;
            _uow = uow;
        }

        public void Update(Role role)
        {
            var roleFromDb = _db.Roles.FirstOrDefault(r => r.Id == role.Id);
            if (roleFromDb != null)
            {
                if (roleFromDb != null)
                {
                    roleFromDb.Designation = role.Designation;
                    _db.SaveChanges();
                }
            }
        }
    }
}
