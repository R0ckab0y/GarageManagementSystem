using GMS.Domain.Common;
using GMS.Domain.Enums;
namespace GMS.Domain.Entities;

public class ServiceItem : BaseEntity
{
    public ServiceType ServiceType { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal LaborCost { get; set; }
    public decimal PartsCost { get; set; }
    public decimal TotalCost { get; set; }
    public int Quantity { get; set; } = 1;

    // Foreign Key
    public Guid ServiceOrderId { get; set; }

    // Navigation Properties
    public ServiceOrder ServiceOrder { get; set; } = null!;
}
