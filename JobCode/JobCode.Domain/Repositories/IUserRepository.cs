using JobCode.Core.Entities;

namespace JobCode.Core.Repositories;

public interface IUserRepository 
{
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(User entity, CancellationToken cancellationToken);
    Task UpdateAsync(User entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(User entity, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
}

