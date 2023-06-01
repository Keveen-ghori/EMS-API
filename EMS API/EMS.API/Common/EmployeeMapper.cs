using EMS.API.DTO.Employee;
using EMS.Data.Models;

namespace EMS.API.Common
{
    public static class EmployeeMapper
    {
        public static GetEmployee MapToModel(Employee entity)
        {
            var model = new GetEmployee
            {
                EmployeeId = entity.EmployeeId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                DOB = entity.DOB,
                Gender = entity.Gender,
                UserName = entity.UserName
            };

            return model;
        }
    }
}