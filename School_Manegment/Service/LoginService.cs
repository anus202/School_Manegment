using Azure;
using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Models;
using static School_Manegment.Payload.ApplicationDTO;

namespace School_Manegment.Service
{
    public class LoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public LoginService(IUnitOfWork unitOfWork, JwtService jwtService = null)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> AddAsync(Login login)
        {
            try
            {
                var res = string.Empty;

                await _unitOfWork.login.AddAsync(login);
                await _unitOfWork.SaveAsync();

                res = "Login Added Successfully";

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.login.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
   

        public async Task<IEnumerable<Login>> GetAllAsync()
        {
            try
            {
                var getData = await _unitOfWork.login.GetAllAsync();

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Login> GetByIdAsync(int id)
        {
            try
            {
                var getData = await _unitOfWork.login.GetByIdAsync(id);

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Login login)
        {
            try
            {
                await _unitOfWork.login.UpdateAsync(login);

                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LoginResponseDto?> AuthenticateAsync(Login login)
        {
            var logins = await _unitOfWork.login.GetAllAsync();

            var authenticatedLogin = logins.FirstOrDefault(x =>
                x.Email == login.Email &&
                x.Password == login.Password);

            // Agar user na mile to null return hoga
            if (authenticatedLogin == null)
            {
                return null;
            }

            // Token generate hoga
            var token = _jwtService.GenerateToken(authenticatedLogin);

            return new LoginResponseDto
            {
                Token = token,
                Message = "Login authenticated successfully"
            };
        }
    }
}
