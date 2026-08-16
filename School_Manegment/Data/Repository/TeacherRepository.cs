using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Teacher teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
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
                var teacher = await _context.Teachers.FindAsync(id);
                if (teacher != null)
                {
                    _context.Teachers.Remove(teacher);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            try
            {
                return await _context.Teachers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            try
            {
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
