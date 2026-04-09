using GMS.Domain.Enums;

namespace GMS.Application.DTOs.Request
{
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}