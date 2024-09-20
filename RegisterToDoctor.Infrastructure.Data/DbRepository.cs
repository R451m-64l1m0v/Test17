using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domen.Core.Common;
using RegisterToDoctor.Infrastructure.Data.Context;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Infrastructure.Data
{
    public class DbRepository<T> : IDbRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext DbContext;

        public DbRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IQueryable<T> Entity => DbContext.Set<T>();
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(T t)
        {
            await DbContext.Set<T>().AddAsync(t);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T t)
        {
            DbContext.Set<T>().Remove(t);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            DbContext.Set<T>().Update(t);
            await DbContext.SaveChangesAsync();
        }
    }
}
