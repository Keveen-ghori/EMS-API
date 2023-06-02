using EMS.API.DTO.Employee;
using EMS.Application.Common;
using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Contract
{
    public interface IEmployeeRepository : IGenericRepositoryBase<Employee>
    {

    }
}
