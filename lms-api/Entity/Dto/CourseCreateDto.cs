namespace LMS_API.Entity.Dto
{

    public class CourseCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
    }
}
