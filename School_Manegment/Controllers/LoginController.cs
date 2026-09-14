using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models;
using School_Manegment.Service;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpGet("/Login/LoginForm")]
        public IActionResult LoginForm()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Autrize")]
        public async Task<IActionResult> Autrize(
            [FromBody] LoginRequest login)
        {
            var res = await _service.AuthenticateAsync(login);

            if (res == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "Invalid email or password",
                    token = (string?)null
                });
            }

            return Ok(new
            {
                success = true,
                message = res.Message,
                token = res.Token
            });
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> AddAsync(
            [FromBody] Login login)
        {
            try
            {
                var res = await _service.AddAsync(login);

                return Ok(new
                {
                    success = true,
                    message = res
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpGet("ForgetPass")]
        public async Task<IActionResult> ForgetPass(string email)
        {
            var login = await _service.ForgetPass(email);

            if (login == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "Login failed",
                    data = login
                });
            }

            return Ok(new
            {
                success = true,
                message = "Login successfully",
                data = login
            });
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string email)
        {
            try
            {
                await _service.GetAllAsync();

                return Ok(new
                {
                    success = true,
                    message = "Logout successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }



        [HttpPut("InactiveUser/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return Ok(new
                {
                    success = true,
                    message = "User inactive successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }


        [HttpPut("ActiveUser/{id}")]
        public async Task<IActionResult> ActiveUser(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return Ok(new
                {
                    success = true,
                    message = "User activated successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }
    }
}