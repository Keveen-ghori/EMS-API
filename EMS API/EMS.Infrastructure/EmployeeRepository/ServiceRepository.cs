using EMS.Application.IEmployeeService;
using EMS.Data.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.EmployeeRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly EmployeeManagementContext context;
        private IEmployeeRepository? Emp;

        public IEmployeeRepository Employee
        {
            get
            {
                if (Emp == null)
                {
                    Emp = new EmployeeRepository(context);
                }
                return Emp;
            }
        }

        public ServiceRepository(EmployeeManagementContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
