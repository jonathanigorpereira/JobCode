using JobCode.Core.Entities;

namespace JobCode.Core.Repositories;

public interface IUserRepository
{
    Task<int> AddAsync(User entity, CancellationToken cancellationToken);
    Task<bool> ExistUserAsync(User entity, CancellationToken cancellationToken);
}

