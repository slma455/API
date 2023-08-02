using FormulaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FormulaAPI.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext apiDbContext;
        internal DbSet<T> dbset;
        protected readonly ILogger logger;
        public GenericRepository(ApiDbContext apiDbContext, ILogger logger)
        {
            this.apiDbContext = apiDbContext;
            this.dbset = apiDbContext.Set<T>();
            this.logger = logger;
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbset.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Delete(T entity)
        {
            dbset.Remove(entity);
            return true;
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            dbset.Update(entity);
            return true;
        }
    }
}
