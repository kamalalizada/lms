namespace LMS_API.Entity.Concrete
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int InstructorId { get; set; }

        public string? Category { get; set; }
        public bool IsPublished { get; set; }

        public Instructor Instructor { get; set; }

        public List<Student> Students { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        public ICollection<Module> Modules { get; set; }



    }
}
