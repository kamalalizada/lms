namespace LMS_API.Entity.Concrete;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ModuleId { get; set; }

    public Module Module { get; set; }
}
