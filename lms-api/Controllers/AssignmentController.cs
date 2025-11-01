using LMS_API.Business.Abstract;
using LMS_API.Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController:ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpPost]
    public IActionResult Create(AssignmentCreateDto dto)
    {
        _assignmentService.Create(dto);
        return Ok();
    }

    [HttpGet("course/{courseId}")]
    public IActionResult GetByCourse(int courseId)
    {
        var result = _assignmentService.GetByCourse(courseId);
        return Ok(result);
    }

}
