using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Response
{
    public class ServiceOrderResponse
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime ReceivedDate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public VehicleStatus Status { get; set; }
        public string StatusName => Status.ToString();
        public string? CustomerComplaints { get; set; }
        public string? TechnicianNotes { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentStatusName => PaymentStatus.ToString();
        public Guid VehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public Guid AssignedMechanicId { get; set; }
        public string MechanicName { get; set; } = string.Empty;
        public List<ServiceItemResponse> ServiceItems { get; set; } = new();
        public List<PaymentResponse> Payments { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

    public class ServiceItemResponse
    {
        public Guid Id { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ServiceTypeName => ServiceType.ToString();
        public string Description { get; set; } = string.Empty;
        public decimal LaborCost { get; set; }
        public decimal PartsCost { get; set; }
        public decimal TotalCost { get; set; }
        public int Quantity { get; set; }
    }
}