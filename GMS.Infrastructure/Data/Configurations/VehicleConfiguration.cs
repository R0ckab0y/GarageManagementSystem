using Microsoft.EntityFrameworkCore;
using GMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMS.Infrastructure.Data.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.Make).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Model).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Year).IsRequired();

        builder.Property(x => x.LicensePlate).IsRequired().HasMaxLength(20);
        builder.HasIndex(x => x.LicensePlate).IsUnique();

        builder.Property(x => x.VIN).HasMaxLength(17);

        builder.Property(x => x.Color).HasMaxLength(30);

        builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);

        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.Property(x => x.DeletedBy).HasMaxLength(100);


        // Global Query Filter for Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        //Relationships
        builder.HasOne(x => x.customer)
                .WithMany(x => x.vehicles)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.serviceOrders)
                .WithOne(x => x.Vehicle)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
