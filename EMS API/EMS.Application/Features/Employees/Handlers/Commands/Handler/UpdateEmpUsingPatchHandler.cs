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
            var employeeEntities = await unitOfWorks.Employee.GetAllAsync(x => x.Deleted_AT == null);
            if (employeeEntities == null || !employeeEntities.Any())
            {
                throw new InvalidOperationException("No employees found.");
            }

            // Apply the patch operations to each Employee entity
            var patchedEmployeeDto = new EmployeeForUpdateDto();
            request.employeeForUpdateDto.ApplyTo(patchedEmployeeDto);

            foreach (var employeeEntity in employeeEntities)
            {
                // Map the patched EmployeeForUpdateDto to the Employee entity
                mapper.Map(patchedEmployeeDto, employeeEntity);
            }

            // Update all the employee entities
            unitOfWorks.QueryEmployee?.UpdateEmpUsingpatch(employeeEntities);

            return Unit.Value;
        }




    }
}
