namespace School_Manegment.Models
{
    public class CommonField
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
    }
}
