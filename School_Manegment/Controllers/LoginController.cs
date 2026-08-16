using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models;
using School_Manegment.Service;

namespace School_Manegment.Controllers
{
    [Authorize] 
    [ApiController] 
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly LoginService _service;
        public LoginController(LoginService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<JsonResult> GetAll()
        {
            var login = await _service.GetAllAsync();
            if (login == null)
            {
                return Json(new
                {
                    Success = "Login Field", data = login
                });
            }

            return Json(new
            {
                Success = "Login Suucefully",
                data = login
            });
        }
        [AllowAnonymous]
        [HttpPost("Autrize")]
        public async Task<JsonResult> Autrize([FromBody] Login login)
        {
            var res = await _service.AuthenticateAsync(login);

            if (res == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Invalid email or password",
                    token = (string?)null
                });
            }

            return Json(new
            {
                success = true,
                message = res.Message,
                token = res.Token
            });
        }
        [HttpPost("addAsync")]
        public async Task<JsonResult> AddAsync([FromBody] Login login)
        {
            try
            {
                var res = await _service.AddAsync(login);
                return Json(new { message = res });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Json(new { message = "Login deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
