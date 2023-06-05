using EMS.Application.Common;
using EMS.Application.Contract;
using EMS.Data.Models;
using EMS.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.EmployeeRepository
{
    public class UnitOfWorks : IunitOfWorks
    {
        private readonly EmployeeManagementContext context;

        public UnitOfWorks(EmployeeManagementContext context)
        {
            this.context = context;
            Employee = new EmployeeRepository(this.context);
            QueryEmployee = new CustomEmployeeRepository(this.context);

        }
        public ICustomEmployeeRepository QueryEmployee { get; set; }
        public IEmployeeRepository Employee { get; set; }
    }
}
