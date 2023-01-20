using System.ComponentModel.DataAnnotations;

namespace MyMVCAPI.Models
{
    public class Course
    {
        [Key]
        
        public int CId { get; set; }
        public string img { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public int? price { get; set; }
        public string? language { get; set; }
        public string? description { get; set; }
        public  virtual ICollection<StuCou> StuCous { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
