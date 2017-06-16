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
        [MaxLength(5)]
        public string Number { get; set; } //Can also have letters

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public Classroom(string number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}
