using School_Manegment.Models;

namespace School_Manegment.Data.Interface
{
    public interface ILoginRepository
    {
        Task<IEnumerable<Login>> GetAllAsync();
        Task<Login> GetByIdAsync(int id);
        Task AddAsync(Login login);
        Task UpdateAsync(Login login);
        Task DeleteAsync(int id);
    }
}
