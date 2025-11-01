using Entity.Concrete;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Mapper;

public class InstructorMapper
{
    public static InstructorDto ToDto(Instructor instructor,User user)
    {
        return new InstructorDto
        {
            Id = instructor.Id,
            UserId = instructor.UserId,
            Name = user.FullName,
            Email = user.Email,
            Department = instructor.Department
        };
    }

    public static Instructor ToEntity(InstructorDto dto)
    {
        return new Instructor
        {
            Id = dto.Id,
            UserId = dto.UserId,
            FullName=dto.Name,
            Email=dto.Email,
            Department = dto.Department,
        };
    }
}
