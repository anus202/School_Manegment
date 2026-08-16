using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Service
{
    public class TeacherExperienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public TeacherExperienceService(IUnitOfWork unitOfWork, JwtService jwtService = null)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> AddAsync(TeacherExperience teacherExperience)
        {
            try
            {
                var res = string.Empty;

                await _unitOfWork.teacherExperience.AddAsync(teacherExperience);
                await _unitOfWork.SaveAsync();

                res = "Teacher Experience Added Successfully";

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
                await _unitOfWork.teacherExperience.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<TeacherExperience>> GetAllAsync()
        {
            try
            {
                var getData = await _unitOfWork.teacherExperience.GetAllAsync();

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeacherExperience> GetByIdAsync(int id)
        {
            try
            {
                var getData = await _unitOfWork.teacherExperience.GetByIdAsync(id);

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(TeacherExperience teacherExperience)
        {
            try
            {
                await _unitOfWork.teacherExperience.UpdateAsync(teacherExperience);

                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
