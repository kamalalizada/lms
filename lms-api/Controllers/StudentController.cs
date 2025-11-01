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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;

        public StudentController(
            IStudentService studentService,
            IUserService userService,
            ICourseService courseService)
        {
            _studentService = studentService;
            _userService = userService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<StudentDto>>>> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            var dtos = new List<StudentDto>();

            foreach (var student in students)
            {
                var user = await _userService.GetByIdAsync(student.UserId);
                var dto = StudentMapper.ToDto(student, user);
                dtos.Add(dto);
            }

            return Ok(ApiResponse<List<StudentDto>>.SuccessResponse(dtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<StudentDto>>> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound(ApiResponse<string>.ErrorResponse($"Student with Id {id} not found."));

            var user = await _userService.GetByIdAsync(student.UserId);
            var dto = StudentMapper.ToDto(student, user);

            return Ok(ApiResponse<StudentDto>.SuccessResponse(dto));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> Add([FromBody] StudentDto dto)
        {
            if (dto == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Invalid student data."));

            var student = StudentMapper.ToEntity(dto);
            await _studentService.AddAsync(student);

            return Ok(ApiResponse<string>.SuccessResponse("Student created successfully."));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, [FromBody] StudentDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest(ApiResponse<string>.ErrorResponse("Student ID mismatch or invalid data."));

            var existing = await _studentService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Student not found."));

            var student = StudentMapper.ToEntity(dto);
            await _studentService.UpdateAsync(student);

            return Ok(ApiResponse<string>.SuccessResponse("Student updated successfully."));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            var existing = await _studentService.GetByIdAsync(id);
            if (existing == null)
                return NotFound(ApiResponse<string>.ErrorResponse($"Student with Id {id} not found."));

            await _studentService.DeleteAsync(id);
            return Ok(ApiResponse<string>.SuccessResponse("Student deleted successfully."));
        }

        // MANY-TO-MANY: Student - Courses

        [HttpPost("{studentId}/courses/{courseId}")]
        public async Task<ActionResult<ApiResponse<string>>> AddCourse(int studentId, int courseId)
        {
            var student = await _studentService.GetByIdAsync(studentId);
            if (student == null)
                return NotFound(ApiResponse<string>.ErrorResponse($"Student with Id {studentId} not found."));

            var course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
                return NotFound(ApiResponse<string>.ErrorResponse($"Course with Id {courseId} not found."));

            var result = await _studentService.AddCourseAsync(studentId, courseId);
            if (!result)
                return BadRequest(ApiResponse<string>.ErrorResponse("Course already assigned to student."));

            return Ok(ApiResponse<string>.SuccessResponse("Course successfully added to student."));
        }

        [HttpDelete("{studentId}/courses/{courseId}")]
        public async Task<ActionResult<ApiResponse<string>>> RemoveCourse(int studentId, int courseId)
        {
            var result = await _studentService.RemoveCourseAsync(studentId, courseId);
            if (!result)
                return NotFound(ApiResponse<string>.ErrorResponse("Relation not found."));

            return Ok(ApiResponse<string>.SuccessResponse("Course successfully removed from student."));
        }

        [HttpGet("{studentId}/courses")]
        public async Task<ActionResult<ApiResponse<List<CourseDto>>>> GetCourses(int studentId)
        {
            var courses = await _studentService.GetCoursesAsync(studentId);

            var dtos = courses.Select(c => CourseMapper.ToDto(c, null)).ToList();

            return Ok(ApiResponse<List<CourseDto>>.SuccessResponse(dtos));
        }

    }
}
