using AutoMapper;
using EMS.Application.Common;
using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies
{
    public class GetEmployeeDetailsHandler : IRequestHandler<EmployeeDetailsRequests, EmployeeDto>
    {
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public GetEmployeeDetailsHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(EmployeeDetailsRequests request, CancellationToken cancellationToken)
        {
            var Emp = await this.unitOfWorks.Employee.GetByIdAsync(x=>x.Deleted_AT == null && x.EmployeeId == request.EmployeeId);
             return this.mapper.Map<EmployeeDto>(Emp);
        }
    }
}
