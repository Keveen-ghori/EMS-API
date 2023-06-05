using EMS.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Common
{
    public interface IunitOfWorks
    {
        ICustomEmployeeRepository QueryEmployee { get; }
        IEmployeeRepository Employee { get; }
    }
}
