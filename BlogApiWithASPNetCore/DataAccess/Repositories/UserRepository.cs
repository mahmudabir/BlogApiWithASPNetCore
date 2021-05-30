using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;
using BlogApiWithASPNetCore.Models.ViewModels;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public UserViewModel GetUserByUsernameNPassword(string username, string password)
        {
            UserViewModel user = new();
            var usernameFromDb = _db.Users.Where(u => u.Username == username).FirstOrDefault();
            var passwordFromDb = _db.Credentials.Where(u => u.Password == password).FirstOrDefault();
            if (usernameFromDb != null && passwordFromDb != null)
            {
                user.Username = usernameFromDb.Username;
                user.Password = passwordFromDb.Password;
                return user;
            }
            return null;
        }

        public User GetUserByUsername(string username)
        {
            var usernameFromDb = _db.Users.Where(u => u.Username == username).FirstOrDefault();
            if (usernameFromDb != null)
            {
                return usernameFromDb;
            }
            return null;
        }

        public void Update(UserViewModel user)
        {
            var userFromDb = _db.Users.FirstOrDefault(u => u.Username == user.Username);
            if (userFromDb != null)
            {
                var credentialFromDb = _db.Credentials.FirstOrDefault(c => c.Id == userFromDb.Id);
                if (credentialFromDb != null)
                {
                    credentialFromDb.Password = user.Password;
                    _db.SaveChanges();
                }
            }
        }

        public void Insert(UserViewModel user)
        {
            var userFromDb = _db.Users.FirstOrDefault(u => u.Username == user.Username);
            if (userFromDb == null)
            {
                var addedUserInDb = _db.Users.Add(new User() { Username = user.Username });
                _db.SaveChanges();
                _db.Credentials.Add(new Credential() { Password = user.Password, UserId = addedUserInDb.Entity.Id });
                _db.SaveChanges();
            }
        }
    }
}
