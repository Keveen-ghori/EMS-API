using EMS.API.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class CreateEmployee: GetEmployee
    {
        [DataMember]
        public DateTime Created_At { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime? Updated_At { get; set; } 

    }
}
