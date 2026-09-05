using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models.Teacher_Tbl;
using School_Manegment.Service;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly TeacherService _service;

        public TeacherController(TeacherService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]

       public async Task<JsonResult> GetAll()              
        {
            var teachers = await _service.GetAllAsync();   
            if (teachers == null)
            {
                return Json(new
                {
                    Success = true, data = teachers
                });
            }
            return Json(new
            {
                Success = false,data = teachers
            });
        }

        [HttpPost("addAsync")]
        public async Task<JsonResult> AddAsync([FromBody] TeacherDetailsDto payload)
        {
            var res = await _service.AddAsync(payload);
            if (res == null)
            {
                return Json(new
                {
                    Success = false,data = res
                });
            }
            return Json(new
            {
                Success = true, data = res
            });
        }

        [HttpGet("GetById/{id}")]
        public async Task<JsonResult> GetById(int id)
        {
            var teacher = await _service.GetByIdAsyncAllTbl(id);
            if (teacher == null)
            {
                return Json(new
                {
                    Success = false, data = teacher
                });
            }
            return Json(new
            {
                Success = true,data = teacher
            });
        }

        [HttpDelete("softDelete/{id}")]
        public async Task<JsonResult> SoftDelete(int id)
        {
            var teacher =  _service.DeleteAsync(id);
            if (teacher == null)
            {
                return Json(new
                {
                    Success = false,data = teacher
                });
            }
            return Json(new
            {
                Success = true, data = teacher
            });
        }
        [HttpPut("restore/{id}")]
        public async Task<JsonResult> Restore(int id)
        {
            var teacher = await _service.GetByIdAsyncAllTbl(id);
            if (teacher == null)
            {
                return Json(new
                {
                    Success = false,data = teacher
                });
            }
            return Json(new
            {
                Success = true, data = teacher
            });
        }

        [HttpPost("assignSubject")]
        public async Task<JsonResult> AssignSubject(int teacherId , string Subject)
        {
            var teacher = await _service.GetAllAsync();
            if (teacher == null)
            {
                return Json(new
                {
                    Success = false,data = teacher
                });
            }
            return Json(new
            {
                Success = true, data = teacher
            });
        }


    }
}
