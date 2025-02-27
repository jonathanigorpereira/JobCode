using JobCode.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCode.Infrastructure;

public class JobCodeDbContext(DbContextOptions<JobCodeDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobCodeDbContext).Assembly);
        
    }
}

