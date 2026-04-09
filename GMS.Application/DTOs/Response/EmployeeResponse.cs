using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Response
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string RoleName => Role.ToString();
        public string Specialization { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
