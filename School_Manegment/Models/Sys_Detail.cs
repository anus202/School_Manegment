using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models
{
    public class Sys_Detail : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string? School { get; set; }
        public string? Logo { get; set; }
        public string? Email { get; set; }
       public string? Password { get; set; }
    }
}
