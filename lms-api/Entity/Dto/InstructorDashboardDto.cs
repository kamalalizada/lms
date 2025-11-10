namespace LMS_API.Entity.Dto;

public class InstructorDashboardDto
{
    public int TotalCourses { get; set; }
    public int TotalStudents { get; set; }
    public int PendingSubmissions { get; set; }
    public List<CourseDashboardItemDto> Courses { get; set; } = new();
}
