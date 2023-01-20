using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMVCAPI.Models
{
    public class Module
    {
        [Key]
        public int MId { get; set; }
        public string? name { get; set; }
        public int CId { get; set; }
        [ForeignKey("CId")]
        public virtual Course? Course { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
