using JobCode.Core.Entities;
using JobCode.Core.Repositories;

namespace JobCode.Infrastructure.Repositories;

public class UserRepository : IBaseRepository<User>
{
    public Task<bool> AddAsync(User entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

