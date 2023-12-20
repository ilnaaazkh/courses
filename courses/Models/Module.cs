using System.ComponentModel.DataAnnotations;

namespace courses.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Title { get; set; } = null!;

        [MaxLength(200)]
        public string? Description { get; set; }
        
        [Required] //TODO:Check if > 0
        public int OrderNumber { get; set; }

        public int CourseId { get; set; }   
        public Course Course { get; set;}

        public List<Lesson> Lessons { get; set; } = new();
    }
}
