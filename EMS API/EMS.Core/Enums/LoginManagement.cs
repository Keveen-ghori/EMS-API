using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Enums
{
    public enum LoginManagement
    {
        [Description("Wrong attemps")]
        Attemps = 0,

        [Description("Total attemps")]
        Total_Attemps = 5,

        [Description("Password expiry days")]
        Exp_days = 7,
    }
}
