﻿using JobCode.Core.Entities;

namespace JobCode.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
