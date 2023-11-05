using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace courses.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;

        [MaxLength(15)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(25)]
        //[RegularExpression("[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", ErrorMessage = "Невалидный адрес электронной почты")]
        public string Email { get; set; } = null!;

        [Required] //TODO: Add constraints for password
        public string Password { get; set; } = null!;//hashcode 

        public List<Course> Courses { get; set; } = new();
    }
}
