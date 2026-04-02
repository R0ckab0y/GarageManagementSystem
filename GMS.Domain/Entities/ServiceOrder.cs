using GMS.Domain.Common;
using GMS.Domain.Enums;

namespace GMS.Domain.Entities;

public class ServiceOrder : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime ReceivedDate { get; set; }
    public DateTime? EstimatedCompletionDate { get; set; }
    public DateTime? ActualCompletionDate { get; set; }
    public VehicleStatus Status { get; set; } = VehicleStatus.Waiting;
    public string? CustomerComplaints { get; set; }
    public string? TechnicianNotes { get; set; }
    public decimal TotalAmount { get; set; }
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    // Foreign Keys
    public Guid VehicleId { get; set; }
    public Guid AssignedMechanicId { get; set; }

    // Navigation Properties
    public Vehicle Vehicle { get; set; } = null!;
    public Employee AssignedMechanic { get; set; } = null!;
    public ICollection<ServiceItem> ServiceItems { get; set; } = new List<ServiceItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
