using JobCode.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCode.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).IsRequired().HasColumnType("NVARCHAR(50)");
        builder.Property(u => u.LastName).IsRequired().HasColumnType("NVARCHAR(80)");
        builder.Property(u => u.BirthDate).IsRequired().HasColumnType("date");
        builder.Property(u => u.Email).IsRequired().HasColumnType("NVARCHAR(256)");
        builder.Property(u => u.Password).IsRequired().HasColumnType("NVARCHAR(128)");
        builder.Property(u => u.Role).IsRequired().HasColumnType("NVARCHAR(20)");
        builder.Property(u => u.Active).IsRequired().HasColumnType("bit").HasDefaultValue(true);

        builder.OwnsOne(u => u.Address, a =>
        {
            a.ToTable("UserAddress");

            a.HasKey(a => a.Id);

            a.Property(a => a.PostalCode).IsRequired().HasColumnType("NVARCHAR(10)").HasMaxLength(10);
            a.Property(a => a.Avenue).IsRequired().HasColumnType("NVARCHAR(100)").HasMaxLength(100);
            a.Property(a => a.Street).IsRequired().HasColumnType("NVARCHAR(100)").HasMaxLength(100);
            a.Property(a => a.District).IsRequired().HasColumnType("NVARCHAR(80)").HasMaxLength(80);
            a.Property(a => a.LocalNumber).IsRequired().HasColumnType("int");
            a.Property(a => a.Complement).HasColumnType("int");
            a.Property(a => a.City).IsRequired().HasColumnType("VARCHAR(100)").HasMaxLength(100);
            a.Property(a => a.State).IsRequired().HasColumnType("VARCHAR(2)").HasMaxLength(2);
            a.Property(a => a.Country).IsRequired().HasColumnType("VARCHAR(100)").HasMaxLength(100);

            a.WithOwner().HasForeignKey("UserId");
        });
    }
}