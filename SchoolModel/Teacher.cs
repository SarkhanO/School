using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(20)]
        public string Patronymic { get; set; }

        public Classroom Classroom { get; set; }
        
    }
}
