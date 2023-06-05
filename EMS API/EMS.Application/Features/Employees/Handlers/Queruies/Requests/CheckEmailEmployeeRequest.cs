using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies.Requests
{
    public class CheckEmailEmployeeRequest : IRequest<bool>
    {
        public string Email { get; set; } = string.Empty;
    }
}
