using System.ComponentModel.DataAnnotations;

namespace courses.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }
        
        //TODO: Check if duration > 0
        public int? Duration { get; set; } //In semestrs

        public List<Student> Students { get; set; } = new();
        public List<Author> Authors { get; set; } = new();

        public List<Module> Modules { get; set; } = new(); 
    }
}
