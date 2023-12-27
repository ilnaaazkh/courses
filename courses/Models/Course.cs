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
        
        public int? Duration { get; set; } //In semestrs

        public List<User> Students { get; set; } = new();
        public List<User> Authors { get; set; } = new();

        public List<Module> Modules { get; set; } = new(); 
    }
}
