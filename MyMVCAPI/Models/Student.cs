using System.ComponentModel.DataAnnotations;

namespace MyMVCAPI.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public virtual ICollection<StuCou> StuCous { get; set; }
    }
}
