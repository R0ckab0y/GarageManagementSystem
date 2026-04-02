using GMS.Domain.Common;

namespace GMS.Domain.Entities;

public class Vehicle : BaseEntity
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public string? VIN { get; set; }
    public string? Color { get; set; }
    public int? Mileage { get; set; }


    //Foreign Key
    public Guid CustomerId { get; set; }

    //Navigation Properties
    public Customer customer { get; set; } = null!;
    public ICollection<ServiceOrder> serviceOrders { get; set; } = new List<ServiceOrder>();

}
