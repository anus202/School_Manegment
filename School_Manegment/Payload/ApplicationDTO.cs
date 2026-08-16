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
    }
}
