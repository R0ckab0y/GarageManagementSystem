namespace GMS.Application.DTOs.Response
{
    public class VehicleResponse
    {
        public Guid Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string? VIN { get; set; }
        public string? Color { get; set; }
        public int? Mileage { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}