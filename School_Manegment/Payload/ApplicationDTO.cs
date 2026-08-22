using School_Manegment.Models;
using School_Manegment.Models.Student_tbl;
using School_Manegment.Models.Teacher_Tbl;

namespace School_Manegment.Payload
{
    public class ApplicationDTO
    {

        public class LoginResponseDto
        {
            public string Token { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
        }

        public class TeacherDetailsDto
        {
            public Teacher Teacher { get; set; }
            public TeacherLoginDetail LoginDetail { get; set; }

            public List<TeacherEducation> Educations { get; set; }

            public List<TeacherExperience> Experiences { get; set; }
        }


        public class StudentDetailsDto
        {
            public Student Student { get; set; }
            public StudentClass studentClass { get; set; }
        }

        public class MasterDto
        {
            public Sys_Detail Detail { get; set; }
            public List<SCH_Class> Classes { get; set; }
            public List<SCH_ClassSection> Sections { get; set; }
            public List<Subject> subjects { get; set; }
        }

    }
}
