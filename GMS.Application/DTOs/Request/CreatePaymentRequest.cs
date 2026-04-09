using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Request
{
    public class CreatePaymentRequest
    {
        public Guid ServiceOrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
    }
}