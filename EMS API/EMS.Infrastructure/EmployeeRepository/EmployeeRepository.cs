using EMS.Application.Contract;
using EMS.Data.Models;
using EMS.Data.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.EmployeeRepository
{
    public class EmployeeRepository : GenericRepositoryBase<Employee>, IEmployeeRepository
    {
        //private readonly EmployeeManagementContext context;
        //public EmployeeRepository(EmployeeManagementContext context) : base(context)
        //{
        //    this.context = context;
        //}

        //public async Task<List<Employee>> GetAll()
        //{
        //    var Emp = await this.context.Employees.Where(emp => emp.Deleted_AT == null).ToListAsync();
        //    return Emp;
        //}

        //public async Task<Employee> GetById(long EmployeeId)
        //{
        //    var Emp = await this.context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == EmployeeId && emp.Deleted_AT == null);
        //    return Emp;
        //}
        public EmployeeRepository(EmployeeManagementContext context) : base(context)
        {
        }
    }
}
