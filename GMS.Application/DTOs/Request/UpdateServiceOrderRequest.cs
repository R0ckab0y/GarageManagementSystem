using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Request
{
    public class UpdateServiceOrderRequest
    {
        public Guid AssignedMechanicId { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public VehicleStatus Status { get; set; }
        public string? TechnicianNotes { get; set; }
        public string? CustomerComplaints { get; set; }
    }
}