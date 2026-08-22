using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models
{
    public class Subject : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string? SubjectName { get; set; }
    }
}
