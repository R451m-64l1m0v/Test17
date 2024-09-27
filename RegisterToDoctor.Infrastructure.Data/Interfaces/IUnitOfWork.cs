using RegisterToDoctor.Domain.Common;

namespace RegisterToDoctor.Infrastructure.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDbRepository<T> DbRepository<T>() where T : BaseEntity;
    }
}