using AutoMapper;
using EMS.Application.Common;
using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using EMS.Application.Features.Employees.Handlers.Queruies.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies.Handler
{
    public class GetEmployeeDetailsHandler : IRequestHandler<EmployeeDetailsRequests, EmployeeDto>
    {
        #region constructor
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public GetEmployeeDetailsHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }
        #endregion
        #region Interface
        public async Task<EmployeeDto> Handle(EmployeeDetailsRequests request, CancellationToken cancellationToken)
        {
            var Emp = await unitOfWorks.Employee.GetByIdAsync(x => x.Deleted_AT == null && x.EmployeeId == request.EmployeeId);
            if (Emp == null)
            {
                throw new InvalidOperationException("Employee does not exists.");
            }
            return mapper.Map<EmployeeDto>(Emp);
        }
        #endregion
    }
}
