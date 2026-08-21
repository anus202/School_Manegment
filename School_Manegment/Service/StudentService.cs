using Hotel_Manegment.Services;
using School_Manegment.Data;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Models.Teacher_Tbl;
using static School_Manegment.Payload.ApplicationDTO;

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

        public async Task<string> AddAsync(StudentDetailsDto payload)
        {
            try
            {
                if (payload == null)
                {
                    return "Student payload cannot be null.";
                }
                var existingStudent = (await _unitOfWork.student.GetAllAsync())
          .Any(x => x.StudentId == payload.Student.StudentId);

                if (existingStudent)
                {
                    throw new Exception("Student ID is already assigned to another student.");
                }

                await _unitOfWork.student.AddAsync(payload.Student);
                await _unitOfWork.SaveAsync();

                var res = new StudentClass
                {
                    FK_StudentId = payload.Student.Id,
                    StudentCode = payload.Student.StudentId,
                    Class = payload.studentClass.Class,
                    Section = payload.studentClass.Section
                };

                await _unitOfWork.studentClass.AddAsync(res);
                await _unitOfWork.SaveAsync();

                return "Student added successfully.";
            }
            catch
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
