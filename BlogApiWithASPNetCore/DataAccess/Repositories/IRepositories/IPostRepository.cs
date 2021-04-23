using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.Models;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        public void Update(Post post);
        public List<Post> PostSearch(string search);
    }
}
