
using LMS_API.Business.Abstract;
using LMS_API.Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _service;
     
    public EnrollmentController(IEnrollmentService service)
    {
        _service = service;
    }

    [HttpPost("enroll")]
    public  IActionResult Enroll([FromBody] EnrollDto dto)
    {
        _service.Enroll(dto.StudentId,dto.CourseId);
        return Ok();
    }

    [HttpDelete("unenroll")]
    public IActionResult Unenroll([FromBody] UnenrollDto dto)
    {
        _service.Unenroll(dto.StudentId,dto.CourseId);
        return Ok();
    }

    [HttpGet("student/{studentId}")]
    public IActionResult GetStudentCourses(int studentId)
    {
        var result = _service.GetStudentCourses(studentId);
        return Ok(result);
    } 
}
