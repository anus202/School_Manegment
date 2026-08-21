using Microsoft.EntityFrameworkCore;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Login> Sys_Logins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherExperience> TeacherExperiences { get; set; }
        public DbSet<TeacherEducation> TeacherEducations { get; set; }
        public DbSet<TeacherLoginDetail> TeacherLoginDetails { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SCH_ClassSection> SCH_ClassSections { get; set; }
        public DbSet<SCH_Class> SCH_Classes { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }


    }
}
