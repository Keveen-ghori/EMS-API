using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Contract
{
    public interface IServiceRepository
    {
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
