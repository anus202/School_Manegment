using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Interface
{
    public interface ITeacherLoginDetailRepository
    {
        Task<IEnumerable<TeacherLoginDetail>> GetAllAsync();
        Task<TeacherLoginDetail> GetByIdAsync(int id);
        Task AddAsync(TeacherLoginDetail loginDetail);
        Task UpdateAsync(TeacherLoginDetail loginDetail);
        Task DeleteAsync(int id);
    }
}
