﻿using AutoMapper;
using EMS.API.Api.Models.ApiModels;
using EMS.Application.Common;
using EMS.Application.Contract;
using EMS.Application.DTO.Employee;
using EMS.Application.Features.Employees.Handlers.Commands;
using EMS.Application.Features.Employees.Handlers.Commands.Requests;
using EMS.Application.Features.Employees.Handlers.Queruies;
using EMS.Application.Features.Employees.Handlers.Queruies.Requests;
using EMS.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [Route("GetAllEmployees")]
        public async Task<ApiResponse<List<EmployeeDto>>> GetAllEmployees()
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
        [Route("GetEmpById/{EmployeeId:long}")]
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
        [Route("CreateEmp")]
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
        [HttpDelete("DeleteEmp/{EmployeeId:long}")]
        public async Task<ApiResponse<NoContentResult>> Delete([FromRoute] long EmployeeId)
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
        [Route("CheckEmailExists/{Email}")]
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

        #region Employee Update
        [HttpPut("UpdateEmp/{EmployeeId:long}")]
        public async Task<ApiResponse<bool>> UpdateEmp([FromBody] UpdateEmployeeDto model, long EmployeeId)
        {
            var apiResponse = new ApiResponse<bool>();

            try
            {
                var command = await _mediator.Send(new UpdateEmployeeRequest { UpdateEmp = model, EmployeeId = EmployeeId });

                return apiResponse.HandleResponse(command);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }

        }
        #endregion

        #region Path method to Update Emp
        [HttpPatch]
        [Route("EmpUpdateForPatch")]
        public async Task<ApiResponse<NoContentResult>> JsonPatchWithModelState(
            [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        {
            var apiResponse = new ApiResponse<NoContentResult>();
            try
            {
                await _mediator.Send(new UpdateEmpUsingPatchRequest
                {
                    employeeForUpdateDto = patchDoc
                });

                return apiResponse.HandleResponse(NoContent());
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }
        #endregion

    }
}

