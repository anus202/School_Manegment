using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Service;

namespace School_Manegment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _service;

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

        [HttpPost("AddAsync")]
        public async Task<JsonResult> AddAsync([FromBody] Student student)
        {
            var result = await _service.AddAsync(student);
            return Json(new
            {
                Success = "Student Added Successfully",
                data = result
            });
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
