using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    public class SaveUpdatedEmployeeDto: UpdateEmployeeDto
    {
        public SaveUpdatedEmployeeDto(UpdateEmployeeDto emp)
        {
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            DOB = emp.DOB;
            Gender = emp.Gender;

            UserName = $"{emp.FirstName} {emp.LastName}";
        }
        public string? UserName { get; set; }
    }
}
