using courses.Models;

namespace courses.Interfaces
{
    public interface ICoursesRepository : IRepository<Course>
    {
        Course Get(int id);

        bool AddStudent(User user, Course course);

        Course GetCourseWithAuthors(int id);
    }
}
