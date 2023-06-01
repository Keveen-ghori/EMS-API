using EMS.Application.Common;
using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.IEmployeeService
{
    public interface IEmployeeRepository: IEmployeeRepositoryBase<Employee>
    {

    }
}
