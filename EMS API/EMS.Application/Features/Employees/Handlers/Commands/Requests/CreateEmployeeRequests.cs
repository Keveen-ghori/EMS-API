using EMS.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands.Requests
{
    public class CreateEmployeeRequests : IRequest<SaveEmployeeDto>
    {
        public CreateEmployeeDto EmployeeDto { get; set; } = new();
        public EmployeeDto newEmp { get; set; } = new();
    }
}
