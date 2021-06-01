using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; set; }
        IPostRepository Post { get; set; }
        ICommentRepository Comment { get; set; }
        ICredentialRepository Credential { get; set; }

        public void Save();
    }
}
