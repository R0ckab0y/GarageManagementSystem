using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Request
{
    public class UpdateEmployeeRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}