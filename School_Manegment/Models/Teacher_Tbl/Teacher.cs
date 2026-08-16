using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models.Teacher_Tbl
{
    public class Teacher : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string? TeacherCode{ get; set; }
        public string? FirstName  { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CNIC { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? JoiningDate { get; set; }
        public string? ProfileImage { get; set; }
        public string? BasicSalary { get; set; }
    }
}
