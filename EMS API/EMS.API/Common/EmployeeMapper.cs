using EMS.API.DTO.Employee;
using EMS.Core.Enums;
using EMS.Data.Models;
using Microsoft.VisualBasic;

namespace EMS.API.Common
{
    public static class EmployeeMapper
    {
        public static GetEmployee MapToModel(Employee entity)
        {
            var model = new GetEmployee
            {
                EmployeeId = entity.EmployeeId,
                FirstName = entity.FirstName ?? "",
                LastName = entity.LastName ?? "",
                Email = entity.Email ?? "" ,
                DOB = entity.DOB.HasValue ? Convert.ToDateTime(entity.DOB.Value.ToString("dd-MM-yyyy")) : null,
                Gender = entity.Gender,
                UserName = entity.UserName ?? ""
            };

            return model;
        }
    }
}