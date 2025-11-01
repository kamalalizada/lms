namespace LMS_API.Entity.Dto;

public class AssignmentCreateDto
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate{ get; set;}

}
