using RegisterToDoctor.Domain.Core.Common;

namespace RegisterToDoctor.Infrastructure.Data.Interfaces
{
    public interface IDbRepository<T> where T : BaseEntity
    {        
        IQueryable<T> Entity { get; }
                        
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
    }
}
