﻿using EMS.API.DTO.Employee;
using EMS.Application.IEmployeeService;
using EMS.Data.Models;
using EMS.Data.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.EmployeeRepository
{
    public class EmployeeRepository : EmployeeRepositoryBase<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(EmployeeManagementContext context) : base(context)
        {

        }
    }
}