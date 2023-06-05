using AutoMapper;
using EMS.Application.DTO.Employee;
using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<SaveEmployeeDto, CreateEmployeeDto>().ReverseMap();
            CreateMap<SaveEmployeeDto, EmployeeDto>().ReverseMap();
        }
    }
}
