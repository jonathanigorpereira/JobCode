using JobCode.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobCode.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Table
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(u => u.BirthDate)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(u => u.Role)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Active)
            .IsRequired()
            .HasDefaultValue(true);

        builder.OwnsOne(u => u.Address, a =>
        {
            a.ToTable("UserAddress");

            a.HasKey(a => a.Id);

            a.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(10);

            a.Property(a => a.Avenue)
                .IsRequired()
                .HasMaxLength(100);

            a.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            a.Property(a => a.District)
                .IsRequired()
                .HasMaxLength(80);

            a.Property(a => a.LocalNumber)
                .IsRequired()
                .HasMaxLength(10);

            a.Property(a => a.Complement)
                .IsRequired()
                .HasMaxLength(10);

            a.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            a.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(2);

            a.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            a.WithOwner().HasForeignKey("UserId");
        });
        #endregion
    }
}

