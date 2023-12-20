using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courses.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Title { get; set; } = null!;

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        public string Content { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
