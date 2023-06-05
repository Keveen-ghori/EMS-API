using EMS.Application.DTO.Employee;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands.Requests
{
    public class UpdateEmpUsingPatchRequest : IRequest<Unit>
    {
        public JsonPatchDocument<EmployeeForUpdateDto> employeeForUpdateDto { get; set; } = new();
        public long Employeeid { get; set; }
    }
}
