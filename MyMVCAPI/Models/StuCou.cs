using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyMVCAPI.Models
{
    public class StuCou
    {
        [Key]
        public int SCId { get; set; }
        public int SId { get; set; }
        [ForeignKey("SId")]
        public Student? Student { get; set; }
        public int CId { get; set; }
        [ForeignKey("CId")]
        public Course? Course { get; set; }

    }

}
