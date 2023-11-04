namespace courses.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } //hashcode 

        public List<Course> Courses { get; set; } = new();
    }
}
