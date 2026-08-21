using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models
{
    public class SCH_ClassSection : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string? SectionName { get; set; }
    }
}
