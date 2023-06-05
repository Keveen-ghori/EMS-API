using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public long EmployeeId { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime? Deleted_AT { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
