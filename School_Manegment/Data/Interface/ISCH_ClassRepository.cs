using School_Manegment.Models;

namespace School_Manegment.Data.Interface
{
    public interface ISCH_ClassRepository
    {
        Task<IEnumerable<SCH_Class>> GetAllAsync();
        Task<SCH_Class> GetByIdAsync(int id);
        Task AddAsync(SCH_Class sCH_Class);
        Task UpdateAsync(SCH_Class sCH_Class);
        Task DeleteAsync(int id);
    }
}
