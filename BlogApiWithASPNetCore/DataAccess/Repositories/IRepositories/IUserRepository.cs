using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
        public User GetUserByUsernameNPassword(string username, string password);
    }
}
