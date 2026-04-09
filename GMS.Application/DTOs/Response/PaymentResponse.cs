using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Response
{
    public class PaymentResponse
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentMethodName => PaymentMethod.ToString();
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public Guid ServiceOrderId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}