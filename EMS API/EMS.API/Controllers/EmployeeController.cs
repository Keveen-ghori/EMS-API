using EMS.API.Api.Models.ApiModels;
using EMS.API.Common;
using EMS.API.DTO.Employee;
using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using EMS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceRepository serviceRepository;

        public EmployeeController(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        [HttpGet]
        public ApiResponse<List<GetEmployee>> Get()
        {
            var apiResponse = new ApiResponse<List<GetEmployee>>();

            try
            {
                List<GetEmployee> model = new List<GetEmployee>();

                var Emp = this.serviceRepository.Employee.GetAll();

                foreach (var item in Emp)
                {
                    model.Add(EmployeeMapper.MapToModel(item));
                }
                return apiResponse.HandleResponse(model);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }

        }

        [HttpGet]
        [Route("{EmployeeId:long}")]
        public ApiResponse<List<GetEmployee>> GetById(long EmployeeId)
        {
            var apiResponse = new ApiResponse<List<GetEmployee>>();

            try
            {
                List<GetEmployee> model = new();

                var Emp = this.serviceRepository.Employee.GetById(emp => emp.EmployeeId == EmployeeId);

                model.Add(EmployeeMapper.MapToModel(Emp.First()));

                return apiResponse.HandleResponse(model);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }

        [HttpPost]
        public ApiResponse<List<GetEmployee>> CreateEmp([FromBody] Employee model)
        {
            var apiResponse = new ApiResponse<List<GetEmployee>>();

            try
            {

                if (ModelState.IsValid)
                {
                    this.serviceRepository.Employee.Create(model);

                    var modelDto = new List<GetEmployee>();
                    modelDto.Add(EmployeeMapper.MapToModel(model));
                    return apiResponse.HandleResponse(modelDto);
                }
                return apiResponse.HandleModelStateFailure(ModelState);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }


    }
}