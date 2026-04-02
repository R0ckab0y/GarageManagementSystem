using GMS.Domain.Common;
using GMS.Domain.Enums;
namespace GMS.Domain.Entities;

public class AppUser : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }

    // Foreign Key (optional - link user to employee)
    public Guid? EmployeeId { get; set; }

    // Navigation
    public Employee? Employee { get; set; }
}
