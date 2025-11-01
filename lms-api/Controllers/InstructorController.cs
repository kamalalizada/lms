using Business.Abstract;
using LMS_API.Business.Abstract;
using LMS_API.Business.Mapper;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IUserService _userService;

        public InstructorController(IInstructorService instructorService, IUserService userService)
        {
            _instructorService = instructorService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<InstructorDto>>>> GetAll()
        {
            var instructors = await _instructorService.GetAllAsync();
            var dtos = new List<InstructorDto>();

            foreach (var instructor in instructors)
            {
                var user = await _userService.GetByIdAsync(instructor.UserId);
                var dto = InstructorMapper.ToDto(instructor, user);
                dtos.Add(dto);
            }

            return Ok(ApiResponse<List<InstructorDto>>.SuccessResponse(dtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<InstructorDto>>> GetById(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Instructor not found"));

            var user = await _userService.GetByIdAsync(instructor.UserId);
            var dto = InstructorMapper.ToDto(instructor, user);

            return Ok(ApiResponse<InstructorDto>.SuccessResponse(dto));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> Add([FromBody] InstructorDto dto)
        {
            if (dto == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Invalid instructor data"));

            var instructor = InstructorMapper.ToEntity(dto);
            await _instructorService.AddAsync(instructor);

            return Ok(ApiResponse<string>.SuccessResponse("Instructor created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, [FromBody] InstructorDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest(ApiResponse<string>.ErrorResponse("Instructor ID mismatch or invalid data"));

            var existing = await _instructorService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Instructor not found"));

            var instructor = InstructorMapper.ToEntity(dto);
            await _instructorService.UpdateAsync(instructor);

            return Ok(ApiResponse<string>.SuccessResponse("Instructor updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            var existing = await _instructorService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Instructor not found"));

            await _instructorService.DeleteAsync(id);
            return Ok(ApiResponse<string>.SuccessResponse("Instructor deleted successfully"));
        }
    }
}
