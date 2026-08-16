using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models.Teacher_Tbl
{
    public class TeacherEducation : CommonField
    {
        [Key]
        public int Id { get; set; }
        public int FK_TeacherId { get; set; }
        public string? TeacherCode { get; set; }
        public string? Institute { get; set; }
        public string? BoardUniversity { get; set; }
        public string? StartYear { get; set; }
        public string? PassingYear { get; set; }
        public string? GradePercentage { get; set; }
        public string? CertificateFile { get; set; }
    }
}
