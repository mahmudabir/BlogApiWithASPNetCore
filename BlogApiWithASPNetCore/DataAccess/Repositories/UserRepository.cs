using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public User GetUserByUsernameNPassword(string username, string password)
        {
            return _db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

        public void Update(User user)
        {
            var objFromDb = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            if (objFromDb != null)
            {
                objFromDb.Password = user.Password;
            }
        }
    }
}
