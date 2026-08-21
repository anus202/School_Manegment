using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Repository
{
    public class SCH_ClassSectionRepository : ISCH_ClassSectionRepository
    {
        private readonly ApplicationDbContext _context;

        public SCH_ClassSectionRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SCH_ClassSection classSection)
        {
            try
            {
                await _context.SCH_ClassSections.AddAsync(classSection);
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
                var classSection = await _context.SCH_ClassSections.FindAsync(id);
                if (classSection != null)
                {
                    _context.SCH_ClassSections.Remove(classSection);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SCH_ClassSection>> GetAllAsync()
        {
            try
            {
                return await _context.SCH_ClassSections.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SCH_ClassSection> GetByIdAsync(int id)
        {
            try
            {
                return await _context.SCH_ClassSections.FirstOrDefaultAsync(cs => cs.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(SCH_ClassSection classSection)
        {
            try
            {
                _context.SCH_ClassSections.Update(classSection);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
