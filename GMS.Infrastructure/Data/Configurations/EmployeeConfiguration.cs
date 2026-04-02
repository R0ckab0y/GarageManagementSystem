using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GMS.Infrastructure.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("NEWSEQUENTIALID");

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);

        builder.Property(x => x.Role).IsRequired().HasConversion<string>();

        builder.Property(x => x.Specialization).IsRequired().HasMaxLength(100);

        builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);

        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.Property(x => x.DeletedBy).HasMaxLength(100);

        //Global Query Filter for Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        //Relationships
        builder.HasMany(x => x.ServiceOrders)
                .WithOne(x => x.AssignedMechanic)
                .HasForeignKey(x => x.AssignedMechanicId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
