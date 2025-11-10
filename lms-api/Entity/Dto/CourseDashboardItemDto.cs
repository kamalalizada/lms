namespace LMS_API.Entity.Dto;

public class CourseDashboardItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Students { get; set; }
    public int Modules { get; set; }
    public int Lessons { get; set; }
    public int PendingSubmissions { get; set; }
}
