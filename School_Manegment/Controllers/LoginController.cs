using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Manegment.Models;
using School_Manegment.Service;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        // Login page
        [HttpGet("/Login/LoginForm")]
        public IActionResult LoginForm()
        {
            return View();
        }


        // =========================
        // LOGIN / AUTHORIZE
        // POST: /api/Login/Autrize
        // =========================
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


        // =========================
        // CREATE USER
        // POST: /api/Login/CreateUser
        // =========================
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


        // =========================
        // FORGET PASSWORD
        // GET: /api/Login/ForgetPass?email=...
        // =========================
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


        // =========================
        // LOGOUT
        // POST: /api/Login/Logout
        // =========================
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


        // =========================
        // INACTIVE USER
        // PUT: /api/Login/InactiveUser/5
        // =========================
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


        // =========================
        // ACTIVE USER
        // PUT: /api/Login/ActiveUser/5
        // =========================
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