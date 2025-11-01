using Entity.Concrete;

namespace LMS_API.Entity.Concrete
{

    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? StudentNumber { get; set; }

        public User User { get; set; }
        public List<Course> Courses { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}