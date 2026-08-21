using School_Manegment.Models;
using School_Manegment.Models.Student_tbl;

namespace School_Manegment.Data.Interface
{
    public interface IStudentClassRepository
    {
        Task<IEnumerable<StudentClass>> GetAllAsync();
        Task<StudentClass> GetByIdAsync(int id);
        Task AddAsync(StudentClass studentClass);
        Task UpdateAsync(StudentClass studentClass);
        Task DeleteAsync(int id);
    }
}
