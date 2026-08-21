using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models.Student_tbl
{
    public class StudentClass : CommonField 
    {
        [Key]
        public int Id { get; set; }
        public int? FK_StudentId { get; set; }
        public string? StudentCode { get; set; }
        public string? Class { get; set; }
        public string? Section { get; set; }
    }
}
