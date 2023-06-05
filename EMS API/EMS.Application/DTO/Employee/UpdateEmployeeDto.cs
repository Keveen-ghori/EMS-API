using EMS.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class UpdateEmployeeDto: EmployeeBaseDto
    {
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        public string? LastName { get; set; } = string.Empty;
        [DataMember]
        public DateTime? DOB { get; set; }
        [DataMember]
        public byte Gender { get; set; } = (byte)EMS.Core.Enums.Gender.Male;
    }
}
