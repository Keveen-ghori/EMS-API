﻿using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using EMS.Data.Models;
using EMS.Data.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EMS.Infrastructure.EmployeeRepository
{
    public class CustomEmployeeRepository: ICustomEmployeeRepository
    {
        private readonly EmployeeManagementContext context;
        public CustomEmployeeRepository(EmployeeManagementContext context) 
        {
            this.context = context;
        }

        public async Task<SaveEmployeeDto> CreateEmployee(SaveEmployeeDto entity)
        {
            var Emp = new Employee
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = Crypto.HashPassword(entity.Password),
                Email = entity.Email,
                Gender = entity.Gender,
                DOB = entity.DOB,
                Password_Updated_At = DateTime.Now,
                UserName = entity.FirstName + " " + entity.LastName

            };
            await this.context.Employees.AddAsync(Emp);
            await this.context.SaveChangesAsync();

            var newEmp = this.context.Employees.FirstOrDefault(emp=>emp.Email == entity.Email);
            SaveEmployeeDto saveEmployeeDto = new SaveEmployeeDto
            {
                EmployeeId = newEmp.EmployeeId,
                UserName = newEmp.UserName,
                Email = newEmp.Email,
                Gender = newEmp.Gender,
                DOB = newEmp.DOB
            };

            return saveEmployeeDto;
        }   

        public async Task UpdateEmployee(SaveUpdatedEmployeeDto entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

    }
}