using GMS.Domain.Common;
using GMS.Domain.Enums;

namespace GMS.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? Notes { get; set; }

    // Foreign Key
    public Guid ServiceOrderId { get; set; }

    // Navigation Properties
    public ServiceOrder ServiceOrder { get; set; } = null!;
}
