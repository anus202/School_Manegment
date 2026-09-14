using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Service;

namespace School_Manegment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassAnsSectionController : Controller
    {
        private readonly ISCH_ClassSectionService _service;

        public ClassAnsSectionController(ISCH_ClassSectionService service)
        {
            _service = service;
        }
        [HttpGet("GetSectionAsync")]

        public async Task<JsonResult> GetSectionAsync()
        {
            var sections = await _service.GetAllClassSectionsAsync();
            if (sections == null)
            {
                return Json(new
                {
                    Success = "No Sections Found",
                    data = sections
                });
            }
            return Json(new
            {
                Success = "Sections Retrieved Successfully",
                data = sections
            });
        }

        [HttpGet("GetClassAsync")]
        public async Task<JsonResult> GetClassAsync()
        {
            var classes = await _service.GetAllClassAsync();
            if (classes == null)
            {
                return Json(new
                {
                    Success = "No Classes Found",
                    data = classes
                });
            }
            return Json(new
            {
                Success = "Classes Retrieved Successfully",
                data = classes
            });
        }
    }
}
