using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolModel
{
    public class Classroom
    {
        [Key]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [Required]
        [MaxLength(7)]
        public string ClassroomNumber { get; set; } //Can also have specific symbols

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Teacher Teacher { get; set; }
    }
}
