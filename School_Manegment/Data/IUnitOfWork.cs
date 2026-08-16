using School_Manegment.Data.Interface;
using School_Manegment.Data.Repository;

namespace School_Manegment.Data
{
    public interface IUnitOfWork
    {
        ILoginRepository login { get; }
        ITeacherRepository teacher { get; }
        ITeacherEducationRepository teacherEducation { get; }
        ITeacherExperienceRepository teacherExperience { get; }
        ITeacherLoginDetailRepository teacherLoginDetail { get; }
        IStudentRepository student { get; }
        Task SaveAsync();
    }
}
