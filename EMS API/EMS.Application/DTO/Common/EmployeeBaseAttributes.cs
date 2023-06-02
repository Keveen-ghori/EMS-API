using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Common
{
    public class EmployeeBaseAttributes
    {
        public long EmployeeId { get; set; }
        public string? UserName { get; set; } = string.Empty;
    }
}
