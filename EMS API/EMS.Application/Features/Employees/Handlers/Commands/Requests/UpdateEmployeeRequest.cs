using EMS.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands.Requests
{
    public class UpdateEmployeeRequest : IRequest<bool>
    {
        public UpdateEmployeeDto UpdateEmp { get; set; } = new();
        public long EmployeeId { get; set; }
    }
}
