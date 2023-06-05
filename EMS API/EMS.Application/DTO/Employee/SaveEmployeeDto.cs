using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    public class SaveEmployeeDto : CreateEmployeeDto
    {
        public long EmployeeId { get; set; }
        public string? UserName { get; set; }

        public SaveEmployeeDto()
        {
            // Parameterless constructor
        }

        public SaveEmployeeDto(CreateEmployeeDto emp)
        {
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            Email = emp.Email;
            Password = emp.Password;
            DOB = emp.DOB;
            Gender = emp.Gender;

            UserName = $"{emp.FirstName} {emp.LastName}";
        }
    }
}
