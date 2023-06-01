﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.IEmployeeService
{
    public interface IServiceRepository
    {
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
