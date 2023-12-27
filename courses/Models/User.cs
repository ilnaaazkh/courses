using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courses.Models
{
    public class User : IdentityUser<int> 
    {
        
        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;

        [MaxLength(15)]
        public string? Surname { get; set; }


        public List<Course> Courses { get; set; } = new();

        public List<Course> CoursesAuthorship { get; set; } = new();
    }
}
