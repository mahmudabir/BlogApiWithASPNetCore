using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface ICredentialRepository : IRepository<Credential>
    {
        void Update(Credential credential);
    }
}
