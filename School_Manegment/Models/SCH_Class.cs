using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models
{
    public class SCH_Class : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}
