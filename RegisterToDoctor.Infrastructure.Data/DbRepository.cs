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

        public IQueryable<T> Entity => DbContext.Set<T>();

        public DbRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Delete(T t)
        {
            DbContext.Set<T>().Remove(t);
            DbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return DbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T t)
        {
            DbContext.Set<T>().Add(t);
            DbContext.SaveChanges();
        }

        public void Update(T t)
        {
            DbContext.Set<T>().Update(t);
            DbContext.SaveChanges();
        }
    }
}
