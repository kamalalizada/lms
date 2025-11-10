using LMS_API.Business.Abstract;
using LMS_API.Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmissionController:ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionController (ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    } 

    [HttpPost]
    public async Task<IActionResult> Submit([FromForm] SubmissionCreateDto dto)
    {
        await _submissionService.SubmissionAsync(dto);
        return Ok();
    }

    [HttpPatch("{id}/grade")]
    public IActionResult Grade (int id,[FromBody] GradeDto dto)
    {
        _submissionService.Grade(id, dto);
        return Ok();
    }

    [HttpGet("assignment/{assignmentId}")]
    public IActionResult GetByAssignment(int assignmentId)
    {
        var result = _submissionService.GetSubmissionByAssignment(assignmentId);
        return Ok(result);
    }

    [HttpGet("student/{studentId}")]
    public IActionResult GetByStudent(int studentId)
    {
        var result =_submissionService.GetSubmissionByStudent(studentId);
        return Ok(result);
    }

    [HttpGet("stats/{assignmentId}")]
    public IActionResult GetStats(int assignmentId)
    {
        var result  = _submissionService.GetStats(assignmentId);
        return Ok(result);
    }
     
     

}
