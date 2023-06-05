using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands
{
    public class DeleteEmployeeRequests: IRequest
    {
        public long EmployeeId { get; set; }
    }
}
