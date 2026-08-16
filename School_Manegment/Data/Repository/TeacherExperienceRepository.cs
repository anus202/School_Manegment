using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Repository
{
    public class TeacherExperienceRepository : ITeacherExperienceRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TeacherExperience teacherExperience)
        {
            try
            {
                await _context.TeacherExperiences.AddAsync(teacherExperience);
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
                var teacher = await _context.TeacherExperiences.FindAsync(id);
                if (teacher != null)
                {
                    _context.TeacherExperiences.Remove(teacher);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TeacherExperience>> GetAllAsync()
        {
            try
            {
                return await _context.TeacherExperiences.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TeacherExperience> GetByIdAsync(int id)
        {
            try
            {
                return await _context.TeacherExperiences.FirstOrDefaultAsync(te => te.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(TeacherExperience teacherExperience)
        {
            try
            {
                _context.TeacherExperiences.Update(teacherExperience);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
