using JobCode.Core.Entities;
using JobCode.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace JobCode.Infrastructure.Repositories;

public class UserRepository(IRepositoryBase<User> repositoryBase, JobCodeDbContext context) : IUserRepository
{
    private readonly IRepositoryBase<User> _repository = repositoryBase;
    private readonly JobCodeDbContext _context = context;
  
    public async Task<int> AddAsync(User entity, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public async Task<bool> ExistUserAsync(User entity, CancellationToken cancellationToken)
    {
        if (entity is null)
            ArgumentNullException.ThrowIfNull(entity);

        var parameters = Expression.Parameter(typeof(User), "x");

        var ignoreProperties = new HashSet<string> { "Id", "CreatedAt", "IsDeleted", "Address" };

        var properties = typeof(User).GetProperties()
                                 .Where(p => !ignoreProperties.Contains(p.Name))
                                 .ToList();

        var equalityTasks = properties.Select(property => Task.Run(() =>
        {
            var propertyValue = property.GetValue(entity);
            var propertyExpression = Expression.Property(parameters, property);
            var constantExpression = Expression.Constant(propertyValue, property.PropertyType);
            return Expression.Equal(propertyExpression, constantExpression);
        })).ToArray();

        var equalityExpressions = await Task.WhenAll(equalityTasks);

        var combinedExpression = equalityExpressions.Aggregate((current, next) => Expression.AndAlso(current, next));

        var lambda = Expression.Lambda<Func<User, bool>>(combinedExpression, parameters);

        return await _context.Users
                                .AsNoTracking()
                                .AnyAsync(lambda, cancellationToken);
    }
}

