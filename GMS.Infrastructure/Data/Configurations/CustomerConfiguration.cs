using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMS.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);

        builder.Property(x => x.Address).HasMaxLength(100);

        builder.Property(x => x.City).HasMaxLength(20);

        builder.Property(x => x.State).HasMaxLength(10);

        builder.Property(x => x.ZipCode).HasMaxLength(10);

        builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);

        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.Property(x => x.DeletedBy).HasMaxLength(100);

        // Global Query Filter for Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        //relationships
        builder.HasMany(x => x.vehicles)
                .WithOne(x => x.customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

    }
}
