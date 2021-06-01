using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.Models;
using BlogApiWithASPNetCore.Models.ViewModels;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        void Update(Role role);
    }
}
