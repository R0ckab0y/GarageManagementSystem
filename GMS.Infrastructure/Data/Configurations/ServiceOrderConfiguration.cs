using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GMS.Infrastructure.Data.Configurations;

public class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder.ToTable("ServiceOrders");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(20);
        builder.HasIndex(x => x.OrderNumber).IsUnique();

        builder.Property(x => x.ReceivedDate).IsRequired();

        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.Property(x => x.CustomerComplaints).HasMaxLength(500);

        builder.Property(x => x.TechnicianNotes).HasMaxLength(500);

        builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(x => x.PaymentStatus).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);

        builder.Property(x => x.UpdatedBy).HasMaxLength(100);

        builder.Property(x => x.DeletedBy).HasMaxLength(100);

        // Global Query Filter for Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        //Relationships

        builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.serviceOrders)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AssignedMechanic)
                .WithMany(x => x.ServiceOrders)
                .HasForeignKey(x => x.AssignedMechanicId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ServiceItems)
                .WithOne(x => x.ServiceOrder)
                .HasForeignKey(x => x.ServiceOrderId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Payments)
                .WithOne(x => x.ServiceOrder)
                .HasForeignKey(x => x.ServiceOrderId)
                .OnDelete(DeleteBehavior.Cascade);

    }
}
