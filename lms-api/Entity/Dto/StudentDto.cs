using System.ComponentModel.DataAnnotations;

namespace LMS_API.Entity.Dto;

public class StudentDto
{
    public int Id { get; set; }
    [Required]
    public int UserId {  get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
