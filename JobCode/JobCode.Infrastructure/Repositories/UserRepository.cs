using JobCode.Core.Entities;
using JobCode.Core.Repositories;

namespace JobCode.Infrastructure.Repositories;

public class UserRepository(JobCodeDbContext context) : IUserRepository
{
    private readonly JobCodeDbContext _context = context;

    public async Task<int> AddAsync(User entity, CancellationToken cancellationToken)
    {
        try
        {
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Erro ao registrar usuário: {ex.InnerException}");
        }
      
    }

    public Task<bool> DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
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

