namespace LMS_API.Entity.Concrete;

public class Assignment
{
    public int Id { get; set; } 
    public int CourseId {  get; set; }
    public string Title {  get; set; }
    public string Description { get; set; }

    public DateTime DueDate { get; set; }
    public Course Course { get; set; }
}
