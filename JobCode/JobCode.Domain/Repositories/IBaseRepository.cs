using JobCode.Core.Entities;

namespace JobCode.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
