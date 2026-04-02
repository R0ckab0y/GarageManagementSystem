using GMS.Domain.Common;
using GMS.Domain.Enums;

namespace GMS.Domain.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string Specialization { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

}
