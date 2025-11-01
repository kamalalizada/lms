using Entity.Concrete;

namespace LMS_API.Entity.Concrete
{

    public class Instructor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        public User User { get; set; }
        public List<Course> Courses { get; set; }
    }
}
