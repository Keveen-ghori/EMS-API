using AutoMapper;
using EMS.API.Api.Models.ApiModels;
using EMS.Application.Common;
using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using EMS.Application.Features.Employees.Handlers.Commands;
using EMS.Application.Features.Employees.Handlers.Queruies;
using EMS.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;


        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get All Employees
        [HttpGet]
        public async Task<ApiResponse<List<EmployeeDto>>> GetEmployees()
        {
            var apiResponse = new ApiResponse<List<EmployeeDto>>();

            try
            {
                var employees = await _mediator.Send(new GetEmployeeListRequests());
                return apiResponse.HandleResponse(employees);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }
        #endregion

        #region Get Employees
        [HttpGet]
        [Route("{EmployeeId:long}")]
        public async Task<ApiResponse<EmployeeDto>> GetEmpById([FromRoute] long EmployeeId)
        {
            var apiResponse = new ApiResponse<EmployeeDto>();

            try
            {
                var employee = await _mediator.Send(new EmployeeDetailsRequests { EmployeeId = EmployeeId });
                return apiResponse.HandleResponse(employee);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }

        }
        #endregion

        #region Create Employee
        [HttpPost]
        public async Task<ApiResponse<long>> CreateEmp([FromBody] CreateEmployeeDto model)
        {
            var apiResponse = new ApiResponse<long>();

            try
            {
                // Validate the model
                if (!ModelState.IsValid)
                {
                    return apiResponse.HandleModelStateFailure(ModelState);
                }
                
                var newEmp = await _mediator.Send(new CreateEmployeeRequests { EmployeeDto = model });
                return apiResponse.HandleResponse(newEmp.EmployeeId);

            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }
        #endregion

        #region Delete Employee
        [HttpDelete("{EmployeeId:long}")]
        public async Task<ApiResponse<NoContentResult>> Delete([FromRoute]long EmployeeId)
        {
            var apiResponse = new ApiResponse<NoContentResult>();
            try
            {
                var command = new DeleteEmployeeRequests { EmployeeId = EmployeeId };
                await _mediator.Send(command);
                return apiResponse.HandleResponse(NoContent());
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }

        #endregion

        #region Check Email
        [HttpGet]
        [Route("{Email}")]
        public async Task<ApiResponse<bool>> CheckEmail([FromRoute] string Email)
        {
            var apiResponse = new ApiResponse<bool>();

            try
            {
                var employee = await _mediator.Send(new CheckEmailEmployeeRequest { Email = Email });
                return apiResponse.HandleResponse(employee);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }

        }
        #endregion
    }
}

