using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;

using Microsoft.EntityFrameworkCore;

namespace BlogApiWithASPNetCore.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Delete(int id)
        {
            this.dbSet.Remove(Get(id));
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public void Insert(T entity)
        {
            this.dbSet.Add(entity);
            _db.SaveChanges();
        }
    }
}
