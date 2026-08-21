using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;

namespace School_Manegment.Data.Repository
{
    public class SCH_ClassRepository : ISCH_ClassRepository
    {
        private readonly ApplicationDbContext _context;

        public SCH_ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SCH_Class sCH_Class)
        {
            try
            {
                await _context.SCH_Classes.AddAsync(sCH_Class);
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
                var classSection = await _context.SCH_Classes.FindAsync(id);
                if (classSection != null)
                {
                    _context.SCH_Classes.Remove(classSection);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SCH_Class>> GetAllAsync()
        {
            try
            {
                return await _context.SCH_Classes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SCH_Class> GetByIdAsync(int id)
        {
            try
            {
                return await _context.SCH_Classes.FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(SCH_Class sCH_Class)
        {
            try
            {
                _context.SCH_Classes.Update(sCH_Class);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
