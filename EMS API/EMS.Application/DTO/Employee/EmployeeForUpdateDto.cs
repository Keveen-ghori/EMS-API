using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class EmployeeForUpdateDto
    {
        [DataMember]
        public int? Total_Attemps { get; set; } = 5;
        [DataMember]
        public int? Exp_days { get; set; } = 7;
    }
}
