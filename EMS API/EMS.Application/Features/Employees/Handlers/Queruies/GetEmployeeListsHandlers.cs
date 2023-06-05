using AutoMapper;
using EMS.Application.Common;
using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using EMS.Data.Settings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies
{
    public class GetEmployeeListsHandlers : IRequestHandler<GetEmployeeListRequests, List<EmployeeDto>>
    {
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public GetEmployeeListsHandlers(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;

        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeListRequests request, CancellationToken cancellationToken)
        {
            var Emp = await this.unitOfWorks.Employee.GetAllAsync(x=>x.Deleted_AT == null);
            return this.mapper.Map<List<EmployeeDto>>(Emp);
        }
    }
}
