using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Delete(int id);
    }
}
