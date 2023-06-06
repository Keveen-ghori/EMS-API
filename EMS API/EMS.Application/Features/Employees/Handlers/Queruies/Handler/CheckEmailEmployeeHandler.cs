using AutoMapper;
using EMS.Application.Common;
using EMS.Application.Features.Employees.Handlers.Queruies.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Handlers.Queruies.Handler
{
    public class CheckEmailEmployeeHandler : IRequestHandler<CheckEmailEmployeeRequest, bool>
    {
        #region const
        private readonly IunitOfWorks unitOfWorks;
        private readonly IMapper mapper;

        public CheckEmailEmployeeHandler(IunitOfWorks unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks;
            this.mapper = mapper;

        }
        #endregion

        #region handler
        public async Task<bool> Handle(CheckEmailEmployeeRequest request, CancellationToken cancellationToken)
        {
            var EmailCheck = await unitOfWorks.Employee.IsEmailExists(x => x.Email == request.Email && x.Deleted_AT == null);
            return EmailCheck;
        }
        #endregion
    }
}
