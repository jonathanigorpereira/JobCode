using JobCode.Core.Entities;
using JobCode.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobCode.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity>(JobCodeDbContext context) : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> _dbSet = context.Set<TEntity>();
        public JobCodeDbContext _context = context;

        public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.Id.Equals(entity.Id) && x.IsDeleted.Equals(false))
                                           .FirstOrDefaultAsync(cancellationToken);

            if (result is not null)
            {
                result.SetAsDeleted();
                _dbSet.Update(result);

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(e => e.Id.Equals(id) && e.IsDeleted.Equals(false), cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter).AsNoTracking();

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            TEntity? entity = await _dbSet.Where(x => x.Id.Equals(id) && x.IsDeleted.Equals(false))
                                           .FirstOrDefaultAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.Id.Equals(entity.Id) && x.IsDeleted.Equals(false))
                                           .FirstOrDefaultAsync(cancellationToken);

            if (result is not null)
            {
                result.SetAsDeleted();
                _dbSet.Update(result);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
