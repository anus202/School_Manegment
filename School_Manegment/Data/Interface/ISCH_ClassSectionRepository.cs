using School_Manegment.Models;
using School_Manegment.Models.Student_tbl;

namespace School_Manegment.Data.Interface
{
    public interface ISCH_ClassSectionRepository
    {
        Task<IEnumerable<SCH_ClassSection>> GetAllAsync();
        Task<SCH_ClassSection> GetByIdAsync(int id);
        Task AddAsync(SCH_ClassSection classSection);
        Task UpdateAsync(SCH_ClassSection classSection);
        Task DeleteAsync(int id);
    }
}
