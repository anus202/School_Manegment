using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;

namespace School_Manegment.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Login login)
        {
            try
            {
                await _context.Sys_Logins.AddAsync(login);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var login = await _context.Sys_Logins.FindAsync(id);
                if (login != null)
                {
                    _context.Sys_Logins.Remove(login);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Login>> GetAllAsync()
        {
            try
            {
                return await _context.Sys_Logins.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Login> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Sys_Logins.FirstOrDefaultAsync(l => l.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Login login)
        {
            try
            {
                _context.Sys_Logins.Update(login);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
