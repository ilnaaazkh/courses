using courses.Models;

namespace courses.Interfaces
{
    public interface ICoursesRepository : IRepository<Course>
    {
        Course GetCourse(int id);

        bool AddStudent(User user, Course course);

        Course GetCourseWithAuthors(int id);
    }
}
