using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GMS.Infrastructure.Data.Configurations;

public class ServiceItemConfiguration : IEntityTypeConfiguration<ServiceItem>
{
    public void Configure(EntityTypeBuilder<ServiceItem> builder)
    {
        builder.ToTable("ServiceItems");

        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.ServiceType).IsRequired().HasConversion<string>();

        builder.Property(x => x.Description).IsRequired().HasMaxLength(100);

        builder.Property(x => x.LaborCost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

        builder.Property(x => x.PartsCost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.TotalCost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(x => x.CreatedBy)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.UpdatedBy)
            .HasMaxLength(100);

        builder.Property(x => x.DeletedBy)
            .HasMaxLength(100);

        // Global Query Filter for Soft Delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        // Relationships
        builder.HasOne(x => x.ServiceOrder)
            .WithMany(x => x.ServiceItems)
            .HasForeignKey(x => x.ServiceOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
