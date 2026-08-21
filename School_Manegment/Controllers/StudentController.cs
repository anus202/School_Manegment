using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Service;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<JsonResult> GetAll()
        {
            var students = await _service.GetAllAsync();
            if (students == null)
            {
                return Json(new
                {
                    Success = "No Students Found",
                    data = students
                });
            }
            return Json(new
            {
                Success = "Students Retrieved Successfully",
                data = students
            });
        }
        [AllowAnonymous]
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] StudentDetailsDto student)
            {
            try
            {
                if (student == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Student payload cannot be null."
                    });
                }

                var result = await _service.AddAsync(student);

                return Ok(new
                {
                    success = true,
                    message = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    error = ex.Message
                });
            }
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Json(new
            {
                Success = "Student Deleted Successfully"
            });
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<JsonResult> GetByIdAsync(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null)
            {
                return Json(new
                {
                    Success = "Student Not Found"
                });
            }
            return Json(new
            {
                Success = "Student Retrieved Successfully",
                data = student
            });
        }

        [HttpPut("UpdateAsync")]
        public async Task<JsonResult> UpdateAsync([FromBody] Student student)
        {
            await _service.UpdateAsync(student);
            return Json(new
            {
                Success = "Student Updated Successfully"
            });
        }
    }
}
