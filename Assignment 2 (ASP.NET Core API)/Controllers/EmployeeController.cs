using Assignment_2__ASP.NET_Core_API_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2__ASP.NET_Core_API_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service) {
            _employeeService = service;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                return  Ok(_employeeService.GetEmployeeData());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (await _employeeService.AddEmployeeData(employee))
                {
                    return Ok("");
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                }
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employee)
        {
            try
            {
                if (await _employeeService.UpdateEmployeeData(id, employee))
                {
                    return Ok("");
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                if (await _employeeService.DeleteEmployeeData(id))
                {
                    return Ok("");
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
