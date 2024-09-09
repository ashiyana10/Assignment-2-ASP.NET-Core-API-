using Assignment_2__ASP.NET_Core_API_.Data;
using Assignment_2__ASP.NET_Core_API_.Models;
using Assignment_2__ASP.NET_Core_API_.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2__ASP.NET_Core_API_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                return Ok(await _departmentService.GetDepartmentData());
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("Add")]
        public async Task<IActionResult> AddDepartmentAsync([FromBody] Department department)
        {
            try
            {
               if(await _departmentService.AddDepartmentData(department))
                {
                    return Ok(department);
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] string departmentName)
        {
            try
            {
                if (await _departmentService.UpdateDepartmentData(id, departmentName))
                {
                    return Ok("Updated");
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex) { 
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                if (await _departmentService.DeleteDepartmentData(id))
                {
                    return Ok("");
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex) { 
                return BadRequest(ex);
            }
        }
    }
}