using AutoMapper;
using EMS.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies
{
    public class CheckEmailEmployeeHandler : IRequestHandler<CheckEmailEmployeeRequest, bool>
    {
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public CheckEmailEmployeeHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;

        }
        public async Task<bool> Handle(CheckEmailEmployeeRequest request, CancellationToken cancellationToken)
        {
            var EmailCheck = await this.unitOfWorks.Employee.IsEmailExists(x=>x.Email == request.Email && x.Deleted_AT == null);
            return EmailCheck;
        }
    }
}
