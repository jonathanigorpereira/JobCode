using JobCode.Core.Entities;
using System.Linq.Expressions;

namespace JobCode.Core.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken,
                                           Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
}