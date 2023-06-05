using EMS.Application.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Contract
{
    public interface ICustomEmployeeRepository
    {
        Task<SaveEmployeeDto> CreateEmployee(SaveEmployeeDto entity);
        Task UpdateEmployee(SaveUpdatedEmployeeDto entity);
    }
}
