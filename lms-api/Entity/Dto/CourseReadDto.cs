namespace LMS_API.Entity.Dto
{

    public class CourseReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool IsPublished { get; set; }

        public string IsntructorName { get; set; } = string.Empty;
    }
}
