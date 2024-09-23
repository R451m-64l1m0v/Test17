using RegisterToDoctor.Domain.Core.Common;

namespace RegisterToDoctor.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDbRepository<T> DbRepository<T>() where T : BaseEntity;
    }
}
