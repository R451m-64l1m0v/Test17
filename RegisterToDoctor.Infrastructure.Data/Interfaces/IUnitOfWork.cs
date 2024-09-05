using RegisterToDoctor.Domen.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDbRepository<T> DbRepository<T>() where T : BaseEntity;
    }
}
