using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Common
{
    public class DateTimeProvider:IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
