using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Service;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : Controller
    {
        private readonly Sys_DetailService _service;

        public MasterController(Sys_DetailService service)
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
                    Success = "No  Found",
                    data = students
                });
            }
            return Json(new
            {
                Success = "Retrieved Successfully",
                data = students
            });
        }


        [HttpPost("UpdateAsync")]
        public async Task<JsonResult> UpdateAsync([FromBody] MasterDto payload)
        {
            await _service.Update(payload);
            return Json(new
            {
                Success = "Student Updated Successfully"
            });
        }
    }
}
