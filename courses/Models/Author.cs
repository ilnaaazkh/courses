using System.ComponentModel.DataAnnotations;

namespace courses.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;

        [MaxLength(15)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(25)]
        //[EmailAddress(ErrorMessage = "Невалидный адрес электронной почты")]
        //[RegularExpression("[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", ErrorMessage = "Невалидный адрес электронной почты")]
        public string Email { get; set; } = null!;

        [Required] //TODO: Add password constraints
        public string Password { get; set; } = null!; //hashcode 

        public List<Course> Courses { get; set; } = new();
    }
}
