
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

            var existClass = await _context.SCH_Classes.AnyAsync();

            if (!existClass)
            {
                var classes = new List<SCH_Class>
                {
                    new SCH_Class { ClassName = "Class 1" },
                    new SCH_Class { ClassName = "Class 2" },
                    new SCH_Class { ClassName = "Class 3" },
                    new SCH_Class { ClassName = "Class 4" },
                    new SCH_Class { ClassName = "Class 5" },
                    new SCH_Class { ClassName = "Class 6" },
                    new SCH_Class { ClassName = "Class 7" },
                    new SCH_Class { ClassName = "Class 8" },
                    new SCH_Class { ClassName = "Class 9" },
                    new SCH_Class { ClassName = "Class 10" }
                };

                await _context.SCH_Classes.AddRangeAsync(classes);
                await _context.SaveChangesAsync();
            }
            var existSection = await _context.SCH_ClassSections.AnyAsync();

            if (!existSection)
            {
                var sections = new List<SCH_ClassSection>
                {
                    new SCH_ClassSection { SectionName = "A" },
                    new SCH_ClassSection { SectionName = "B" },
                    new SCH_ClassSection { SectionName = "C" },
                    new SCH_ClassSection { SectionName = "D" }
                };

                await _context.SCH_ClassSections.AddRangeAsync(sections);
                await _context.SaveChangesAsync();
            }


        }
    }
}
