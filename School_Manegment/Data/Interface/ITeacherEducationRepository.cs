using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Interface
{
    public interface ITeacherEducationRepository
    {
        Task<IEnumerable<TeacherEducation>> GetAllAsync();
        Task<TeacherEducation> GetByIdAsync(int id);
        Task AddAsync(TeacherEducation teacherEducation);
        Task UpdateAsync(TeacherEducation teacherEducation);
        Task DeleteAsync(int id);
    }
}
