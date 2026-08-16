using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Service
{
    public class TeacherEducationSevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public TeacherEducationSevice(IUnitOfWork unitOfWork, JwtService jwtService = null)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> AddAsync(TeacherEducation teacherEducation)
        {
            try
            {
                var res = string.Empty;

                await _unitOfWork.teacherEducation.AddAsync(teacherEducation);
                await _unitOfWork.SaveAsync();

                res = "Teacher Education Added Successfully";

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
                await _unitOfWork.teacherEducation.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<TeacherEducation>> GetAllAsync()
        {
            try
            {
                var getData = await _unitOfWork.teacherEducation.GetAllAsync();

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeacherEducation> GetByIdAsync(int id)
        {
            try
            {
                var getData = await _unitOfWork.teacherEducation.GetByIdAsync(id);

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(TeacherEducation teacherEducation)
        {
            try
            {
                await _unitOfWork.teacherEducation.UpdateAsync(teacherEducation);

                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
