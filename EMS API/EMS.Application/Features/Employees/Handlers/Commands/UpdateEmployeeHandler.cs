using AutoMapper;
using EMS.Application.Common;
using EMS.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, bool>
    {
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public UpdateEmployeeHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var Emp = await this.unitOfWorks.Employee.GetByIdAsync(x => x.Deleted_AT == null && x.EmployeeId == request.EmployeeId);
            if (Emp is null)
                throw new InvalidOperationException("Employee not found.");
            this.mapper.Map(request.UpdateEmp, Emp);
            return true;
        }
    }
}
