using AutoMapper;
using EMS.Application.Contract;
using EMS.Application.DTO.Common;
using EMS.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Data.Settings;
using EMS.Application.Common;
using EMS.Application.DTO.Employee;

namespace EMS.Application.Features.Employees.Handlers.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequests, SaveEmployeeDto>
    {
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public CreateEmployeeHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }

        public async Task<SaveEmployeeDto> Handle(CreateEmployeeRequests request, CancellationToken cancellationToken)
        {
            var EmailCheck = await this.unitOfWorks.Employee.IsEmailExists(x => x.Email == request.EmployeeDto.Email && x.Deleted_AT == null);
            if(EmailCheck)
            {
                throw new InvalidOperationException("Email already exists for an employee.");
            }
            var Emp = this.mapper.Map<SaveEmployeeDto>(request.EmployeeDto);
            Emp = await this.unitOfWorks.QueryEmployee.CreateEmployee(Emp);
            return Emp;
        }
    }
}
