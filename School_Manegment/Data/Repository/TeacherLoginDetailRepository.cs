using Microsoft.EntityFrameworkCore;
using School_Manegment.Data.Interface;
using School_Manegment.Models;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Data.Repository
{
    public class TeacherLoginDetailRepository : ITeacherLoginDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherLoginDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TeacherLoginDetail loginDetail)
        {
            try
            {
                await _context.TeacherLoginDetails.AddAsync(loginDetail);
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
                var loginDetail = await _context.TeacherLoginDetails.FindAsync(id);
                if (loginDetail != null)
                {
                    _context.TeacherLoginDetails.Remove(loginDetail);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TeacherLoginDetail>> GetAllAsync()
        {
            try
            {
                return await _context.TeacherLoginDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TeacherLoginDetail> GetByIdAsync(int id)
        {
            try
            {
                return await _context.TeacherLoginDetails.FirstOrDefaultAsync(tld => tld.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(TeacherLoginDetail loginDetail)
        {
            try
            {
                _context.TeacherLoginDetails.Update(loginDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
