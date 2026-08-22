using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;

namespace School_Manegment.Data.Repository
{
    public class Sys_DetailRepository : ISys_DetailRepository
    {
        private readonly ApplicationDbContext _context;

        public Sys_DetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Sys_Detail sysDetail)
        {
            try
            {
                await _context.Sys_Details.AddAsync(sysDetail);
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
                var sysDetail = await _context.Sys_Details.FindAsync(id);
                if (sysDetail != null)
                {
                    _context.Sys_Details.Remove(sysDetail);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Sys_Detail>> GetAllAsync()
        {
            try
            {
                return await _context.Sys_Details.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sys_Detail> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Sys_Details.FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Sys_Detail sysDetail)
        {
            try
            {
                _context.Sys_Details.Update(sysDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
