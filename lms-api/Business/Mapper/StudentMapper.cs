using Entity.Concrete;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Mapper;

public class StudentMapper
{
    public static StudentDto ToDto(Student student,User user)
    {
        return new StudentDto
        {
            Id = student.Id,
            UserId = student.UserId,
            Name = user.FullName,
            Email = user.Email
        };
    }

    public static Student ToEntity(StudentDto dto)
    {
        return new Student
        {
            Id = dto.Id,
            UserId = dto.UserId,
        };
    }

}
