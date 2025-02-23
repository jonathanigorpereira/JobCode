using JobCode.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobCode.Infrastructure;

public class JobCodeDbContext : DbContext
{
    public JobCodeDbContext(DbContextOptions<JobCodeDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(c =>
        {
            c.ToTable("Company", "Company");

            c.HasKey(c => c.Id);

            c.HasMany(c => c.Users)
              .WithOne(u => u.Company)
              .HasForeignKey(u => u.CompanyId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);
        });
       

        modelBuilder.Entity<User>(u=>{
            u.ToTable("User", "Users");

            u.HasKey(u => u.Id);

            u.HasOne(u => u.Company)
             .WithMany(c => c.Users)
             .HasForeignKey(u => u.CompanyId)
             .IsRequired(false)
             .OnDelete(DeleteBehavior.Restrict);

        });


        base.OnModelCreating(modelBuilder);
    }
}

