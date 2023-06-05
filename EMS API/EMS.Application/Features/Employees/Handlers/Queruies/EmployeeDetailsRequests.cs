using EMS.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies
{
    public class EmployeeDetailsRequests : IRequest<EmployeeDto>
    {
        public long EmployeeId { get; set; }
    }
}
