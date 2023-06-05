using AutoMapper;
using EMS.Application.Common;
using EMS.Application.DTO.Employee;
using EMS.Application.Features.Employees.Handlers.Commands.Requests;
using EMS.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands.Handler
{
    public class UpdateEmpUsingPatchHandler : IRequestHandler<UpdateEmpUsingPatchRequest, Unit>
    {

        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public UpdateEmpUsingPatchHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateEmpUsingPatchRequest request, CancellationToken cancellationToken)
        {
            var employeeEntity = await unitOfWorks.Employee.GetByIdAsync(x => x.EmployeeId == request.Employeeid);
            if (employeeEntity == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }

            // Apply the patch operations to the EmployeeForUpdateDto object
            var patchedEmployeeDto = new EmployeeForUpdateDto();
            request.employeeForUpdateDto.ApplyTo(patchedEmployeeDto);

            // Map the patched EmployeeForUpdateDto to the Employee entity
            mapper.Map(patchedEmployeeDto, employeeEntity);

            // Update the employee entity
            unitOfWorks.QueryEmployee.UpdateEmpUsingpatch(employeeEntity);

            return Unit.Value;
        }



    }
}
