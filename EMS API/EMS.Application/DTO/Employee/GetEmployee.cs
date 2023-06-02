using EMS.Application.DTO.Common;
using EMS.Core.Constants;
using EMS.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EMS.API.DTO.Employee
{
    [DataContract]
    public class GetEmployee : EmployeeBaseAttributes
    {
        [Required(ErrorMessage = SystemMessages.FirstNameRequired)]
        [RegularExpression(RegularExpression.FirstName, ErrorMessage = SystemMessages.FirstNameValid)]
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [RegularExpression(RegularExpression.LastName, ErrorMessage = SystemMessages.LastNameValid)]
        [DataMember]
        public string? LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = SystemMessages.EmailRequired)]
        [RegularExpression(RegularExpression.Email, ErrorMessage = SystemMessages.EmailValidation)]
        [DataMember]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = SystemMessages.DOB)]
        [DataType(DataType.Date)]
        [DataMember]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = SystemMessages.GenderRequired)]
        [DataMember]
        public byte Gender { get; set; } = (byte)EMS.Core.Enums.Gender.Male;
    }
}
