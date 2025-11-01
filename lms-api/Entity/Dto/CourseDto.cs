using System.ComponentModel.DataAnnotations;

namespace LMS_API.Entity.Dto;

public class CourseDto
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Title is required")]
    [MaxLength(150)]
    public string Title { get; set; }

    [MaxLength(300)]
    public string Description { get; set; }
    public string InstructorName { get; set; }

    [Required(ErrorMessage ="InstructorId is required")]
    public int InstructorId {  get; set; }
}
