namespace LMS_API.Entity.Concrete;

public class Submission
{
    public int Id { get; set; }
    public int AssignmentId {  get; set; }
    public int StudentId {  get; set; }
    public string? Content {  get; set; }
    public string?  FilePath {  get; set; }
    public DateTime SubmittedAt { get; set; }
    public string Status {  get; set; }
    public int? Grade { get; set; }
    public string Feedback {  get; set; }
    public int CourseId { get; set; }   
    public Course Course { get; set; }

    public Assignment Assignment { get; set; }
    public Student Student { get; set; }
}
