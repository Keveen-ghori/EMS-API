using EMS.API.Common;
using EMS.API.DTO.Employee;
using EMS.Application.IEmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceRepository wrapperRepository;

        public EmployeeController(IServiceRepository wrapperRepository)
        {
            this.wrapperRepository = wrapperRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetEmployee> model = new();

            var Emp = this.wrapperRepository.Employee.GetAll(x => x.Deleted_AT == null);

            foreach (var item in Emp)
            {
                model.Add(EmployeeMapper.MapToModel(item));
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("{EmployeeId:long}")]
        public IActionResult GetById(long EmployeeId)
        {
            List<GetEmployee> model = new();

            var Emp = this.wrapperRepository.Employee.GetById(emp => emp.EmployeeId == EmployeeId);
            if (Emp == null)
            {
                return NotFound();
            }

            model.Add(EmployeeMapper.MapToModel(Emp.First()));

            return Ok(model);
        }
    }
}
