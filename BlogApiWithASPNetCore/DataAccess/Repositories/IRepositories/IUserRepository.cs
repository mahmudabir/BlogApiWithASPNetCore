using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.Models;
using BlogApiWithASPNetCore.Models.ViewModels;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(UserViewModel user);
        void Insert(UserViewModel user);
        public UserViewModel GetUserByUsernameNPassword(string username, string password);
        public User GetUserByUsername(string username);
    }
}
