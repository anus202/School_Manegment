using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Service
{
    public class StudentService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public StudentService(IUnitOfWork unitOfWork, JwtService jwtService = null)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<string> AddAsync(Student student)
        {
            try
            {
                var res = string.Empty;

                await _unitOfWork.student.AddAsync(student);
                await _unitOfWork.SaveAsync();

                res = "Student Added Successfully";

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
                await _unitOfWork.student.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            try
            {
                var getData = await _unitOfWork.student.GetAllAsync();

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            try
            {
                var getData = await _unitOfWork.student.GetByIdAsync(id);

                return getData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Student student)
        {
            try
            {
                await _unitOfWork.student.UpdateAsync(student);

                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
