using School_Manegment.Models;

namespace School_Manegment.Data.Interface
{
    public interface ISys_DetailRepository
    {
        Task<IEnumerable<Sys_Detail>> GetAllAsync();
        Task<Sys_Detail> GetByIdAsync(int id);
        Task AddAsync(Sys_Detail sysDetail);
        Task UpdateAsync(Sys_Detail sysDetail);
        Task DeleteAsync(int id);
    }
}
