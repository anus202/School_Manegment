using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;

namespace School_Manegment.Data.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Subject subject)
        {
            try
            {
                await _context.Subjects.AddAsync(subject);
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
                var classSection = await _context.Subjects.FindAsync(id);
                if (classSection != null)
                {
                    _context.Subjects.Remove(classSection);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            try
            {
                return await _context.Subjects.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Subjects.FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Subject subjects)
        {
            try
            {
                _context.Subjects.Update(subjects);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
