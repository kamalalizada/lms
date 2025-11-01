using Business.Abstract;
using Entity.Concrete;
using LMS_API.Business.Abstract;
using LMS_API.Business.Mapper;
using LMS_API.Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IInstructorService _instructorService;

        public CourseController(ICourseService courseService, IInstructorService instructorService)
        {
            _courseService = courseService;
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllAsync()
        {
            var dtos = await _courseService.GetAllAsync();
            return Ok(ApiResponse<List<CourseDto>>.SuccessResponse(dtos));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetByIdAsync(int id)
        {
            var dto = await _courseService.GetByIdAsync(id);
            if (dto == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Course not found"));

            var instructor = await _instructorService.GetByIdAsync(dto.InstructorId);
            var resultDto = CourseMapper.ToDto(CourseMapper.ToEntity(dto), instructor);

            return Ok(ApiResponse<CourseDto>.SuccessResponse(dto));
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CourseDto dto)
        {
            var instructor = await _instructorService.GetByIdAsync(dto.InstructorId);
            if (instructor == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Instructor not found"));

            await _courseService.AddAsync(dto);

            return Ok(ApiResponse<string>.SuccessResponse("Course created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CourseDto dto)
        {
            var existing = await _courseService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Course not found"));

            var instructor = await _instructorService.GetByIdAsync(dto.InstructorId);
            if (instructor == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Instructor not found"));

            dto.Id = id;

            await _courseService.UpdateAsync(dto);
            return Ok(ApiResponse<string>.SuccessResponse("Course updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Course not found"));

            await _courseService.DeleteAsync(id);
            return Ok(ApiResponse<string>.SuccessResponse("Course deleted successfully"));
        }
    }
}
