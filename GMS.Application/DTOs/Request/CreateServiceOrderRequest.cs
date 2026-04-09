using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Request
{
    public class CreateServiceOrderRequest
    {
        public Guid VehicleId { get; set; }
        public Guid AssignedMechanicId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public string? CustomerComplaints { get; set; }
        public List<CreateServiceItemRequest> ServiceItems { get; set; } = new();
    }

    public class CreateServiceItemRequest
    {
        public ServiceType ServiceType { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal LaborCost { get; set; }
        public decimal PartsCost { get; set; }
        public int Quantity { get; set; } = 1;
    }
}