namespace courses.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; } 
        public int CourseId { get; set; }   
        public Course Course { get; set;}

        public List<Lesson> Lessons { get; set; } = new();
    }
}
