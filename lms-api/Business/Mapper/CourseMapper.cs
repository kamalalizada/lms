using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Mapper
{
    public class CourseMapper
    {
        public static CourseDto ToDto(Course course, Instructor instructor)
        {
            if (course == null) return null;

            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                InstructorId = course.InstructorId,
                InstructorName = instructor?.User?.FullName ?? "Unknown"
            };
        }

        public static CourseDto ToDto(Course course)
        {
            if (course == null) return null;

            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor?.User?.FullName ?? "Unknown"
            };
        }

        public static Course ToEntity(CourseDto dto)
        {
            if (dto == null) return null;

            return new Course
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                InstructorId = dto.InstructorId
               
            };
        }
    }
}
