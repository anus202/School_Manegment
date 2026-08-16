using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Interface
{
    public interface ITeacherExperienceRepository
    {
        Task<IEnumerable<TeacherExperience>> GetAllAsync();
        Task<TeacherExperience> GetByIdAsync(int id);
        Task AddAsync(TeacherExperience teacherExperience);
        Task UpdateAsync(TeacherExperience teacherExperience);
        Task DeleteAsync(int id);
    }
}
