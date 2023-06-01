using EMS.Core.Enums;

namespace EMS.API.DTO.Employee
{
    public class GetEmployee
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public byte Gender { get; set; } = (byte)EMS.Core.Enums.Gender.Male;
        public string? UserName { get; set; } = string.Empty;
    }
}
