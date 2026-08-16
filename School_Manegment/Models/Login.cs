using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models
{
    public class Login : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? Roll { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
