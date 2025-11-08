using LMS_API.Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController : ControllerBase
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

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _assignmentService.GetById(id);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(AssignmentUpdateDto dto)
    {
        _assignmentService.Update(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _assignmentService.Delete(id);
        return Ok();

    }

}
