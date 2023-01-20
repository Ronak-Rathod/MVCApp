using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMVCAPI.Models
{
    public class Lecture
    {
        [Key]
        public int LId { get; set; }
        public string? heading { get; set; }
        public string? src { get; set; }
        public int MId { get; set; }
        [ForeignKey("MId")]
        public virtual Module? Module { get; set; }

        
       
    }
}
