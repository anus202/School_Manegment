using School_Manegment.Data.Interface;
using School_Manegment.Data.Repository;
using School_Manegment.Models;

namespace School_Manegment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ILoginRepository login { get; }
        public ITeacherRepository teacher { get; }
        public ITeacherEducationRepository teacherEducation { get; }
        public ITeacherExperienceRepository teacherExperience { get; }
        public ITeacherLoginDetailRepository teacherLoginDetail { get; }
        public IStudentRepository student { get; }
        public ISCH_ClassSectionRepository classSection { get; }
        public ISCH_ClassRepository sCH_class { get; }
        public IStudentClassRepository studentClass { get; }
        public ISys_DetailRepository sysDetail { get; }
        public ISubjectRepository subject { get; }




        public UnitOfWork(ApplicationDbContext context,
            ILoginRepository loginRepository,
            ITeacherRepository teacherRepository,
            ITeacherEducationRepository teacherEducationRepository,
            ITeacherExperienceRepository teacherExperienceRepository,
            ITeacherLoginDetailRepository teacherLoginDetailRepository,
            IStudentRepository studentRepository,
            ISCH_ClassSectionRepository classSectionRepository,
            ISCH_ClassRepository sCH_classRepository,
            IStudentClassRepository studentClassRepository,
            ISys_DetailRepository sysDetailRepository,
            ISubjectRepository subjectRepository

            )
        {
            _context = context;
            login = loginRepository;
            teacher = teacherRepository;
            teacherEducation = teacherEducationRepository;
            teacherExperience = teacherExperienceRepository;
            teacherLoginDetail = teacherLoginDetailRepository;
            student = studentRepository;
            classSection = classSectionRepository;
            sCH_class = sCH_classRepository;
            studentClass = studentClassRepository;
            sysDetail = sysDetailRepository;
            subject = subjectRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
