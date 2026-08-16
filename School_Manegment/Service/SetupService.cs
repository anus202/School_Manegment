
using Microsoft.EntityFrameworkCore;
using School_Manegment.Models;

namespace Hotel_Manegment.Services
{
    public class SetupService
    {
        private readonly ApplicationDbContext _context;

        public SetupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLogin()
        {
            var exists = await _context.Sys_Logins.AnyAsync();

            if (!exists)
            {
                Login payload = new Login()
                {
                    Email = "Admin@gmail.com",
                    Password = "123"
                };

                await _context.Sys_Logins.AddAsync(payload);
                await _context.SaveChangesAsync();
            }
        }

    }
}
