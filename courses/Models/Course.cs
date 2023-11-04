namespace courses.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; } // в месяцах

        public List<Student> Students { get; set; } = new();
        public List<Author> Authors { get; set; } = new();

        public List<Module> Modules { get; set; } = new(); 
    }
}
