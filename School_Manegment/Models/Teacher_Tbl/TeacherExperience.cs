using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models.Teacher_Tbl
{
    public class TeacherExperience : CommonField
    {
        [Key]
        public int Id { get; set; }
        public int FK_TeacherId { get; set; }
        public string? TeacherCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Responsibilities { get; set; }
        public string? ExperienceCertificate { get; set; }
    }
}
