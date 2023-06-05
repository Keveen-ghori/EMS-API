using AutoMapper;
using EMS.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Commands
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequests>
    {
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public DeleteEmployeeHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeeRequests request, CancellationToken cancellationToken)
        {
            var leaveType = await this.unitOfWorks.Employee.GetByIdAsync(x => x.EmployeeId == request.EmployeeId && x.Deleted_AT == null);
            if (leaveType == null)
            {
                throw new NotImplementedException("Employee not exists.");
            }
            await this.unitOfWorks.Employee.DeleteByIdAsync(leaveType.EmployeeId);
            return Unit.Value;
        }
    
    }
}
