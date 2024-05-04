using EMPLOYEES.DATA.DataModel;
using EMPLOYEES.Model;
using EMPLOYEES.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEES.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        protected IService _service { get; private set; }
        public EmployeesController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("employees_db")]
        public IEnumerable<EmployeesKveletic> GetAllEmployeesDb()
        {
            IEnumerable<EmployeesKveletic> employeesDb = _service.GetAllEmployeesDb();
            return employeesDb;
        }

        [HttpGet]
        [Route("employees_domain")]
        public IEnumerable<EmployeesDomain> GetAllEmployeesDomain()
        {
            return _service.GetAllEmployeesDomain();
        }

        [HttpGet]
        [Route("employee/{employeeId}")]
        public IActionResult GetEmployeeDomainByEmployeeId(int employeeId)
        {
            var employeeDomain = _service.GetEmployeeDomainByEmployeeId(employeeId);
            if (employeeDomain != null)
            {
                return Ok(employeeDomain);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeesDomain employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data");
            }

            try
            {
                bool success = await _service.AddEmployeeAsync(employee);
                if (success)
                {
                    return Ok("Employee added successfully");
                }
                else
                {
                    return StatusCode(500, "Failed to add employee");
                }
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
