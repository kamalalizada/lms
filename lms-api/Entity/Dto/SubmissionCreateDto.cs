namespace LMS_API.Entity.Dto;

public class SubmissionCreateDto
{
    public int AssignmentId {  get; set; }
    public int StudentId {  get; set; }
    public string? Content {  get; set; }
    public IFormFile? File { get; set; }
}
