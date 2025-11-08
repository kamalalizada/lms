namespace LMS_API.Entity.Dto;

public class AssignmentUpdateDto
{
    public int Id { get; set; }
    public string Title {  get; set; }
    public DateTime DueDate { get; set; }
    public string Description { get; set; }
}
