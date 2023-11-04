namespace courses.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int OrderNumber { get; set; }
        public string Content { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
