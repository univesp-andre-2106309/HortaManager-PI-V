using HortaManager.Infrastructure.EntityContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly SqlDatabaseContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(SqlDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await this.dbSet.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
          T? obj = await GetByIdAsync(id);
            if (obj != null)
            {
               this.dbSet.Remove(obj);
               await this.dbContext.SaveChangesAsync();
            }
          
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
           return await dbSet.FindAsync(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return this.dbSet.AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
