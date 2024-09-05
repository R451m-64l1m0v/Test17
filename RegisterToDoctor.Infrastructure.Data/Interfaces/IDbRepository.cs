using RegisterToDoctor.Domen.Core.Common;
using RegisterToDoctor.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Infrastructure.Data.Interfaces
{
    public interface IDbRepository<T> where T : BaseEntity
    {
        //MainContext DbContext { get; }

        IQueryable<T> Entity { get; }

        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
    }
}
