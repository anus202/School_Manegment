using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models.Teacher_Tbl
{
    public class TeacherLoginDetail : CommonField
    {
        [Key]
        public int Id { get; set; }
        public bool IsWebLogin { get; set; }
        public int FK_TeacherId { get; set; }
        public string? TeacherCode { get; set; }
    }
}
