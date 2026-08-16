using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Repository
{
    public class TeacherEducationRepository : ITeacherEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherEducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TeacherEducation teacherEducation)
        {
            try
            {
                await _context.TeacherEducations.AddAsync(teacherEducation);
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
                var teacher = await _context.TeacherEducations.FindAsync(id);
                if (teacher != null)
                {
                    _context.TeacherEducations.Remove(teacher);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TeacherEducation>> GetAllAsync()
        {
            try
            {
                return await _context.TeacherEducations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TeacherEducation> GetByIdAsync(int id)
        {
            try
            {
                return await _context.TeacherEducations.FirstOrDefaultAsync(te => te.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(TeacherEducation teacherEducation)
        {
            try
            {
                _context.TeacherEducations.Update(teacherEducation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
