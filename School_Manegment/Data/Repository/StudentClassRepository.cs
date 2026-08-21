using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Student_tbl;

namespace School_Manegment.Data.Repository
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(StudentClass studentClass)
        {
            try
            {
                await _context.StudentClasses.AddAsync(studentClass);
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
                var classSection = await _context.StudentClasses.FindAsync(id);
                if (classSection != null)
                {
                    _context.StudentClasses.Remove(classSection);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<StudentClass>> GetAllAsync()
        {
            try
            {
                return await _context.StudentClasses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentClass> GetByIdAsync(int id)
        {
            try
            {
                return await _context.StudentClasses.FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(StudentClass studentClass)
        {
            try
            {
                _context.StudentClasses.Update(studentClass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
