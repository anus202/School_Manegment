using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Interface
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
    }
}
