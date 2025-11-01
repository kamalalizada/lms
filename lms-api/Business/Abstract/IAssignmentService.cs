using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Abstract;

public interface IAssignmentService
{
    void Create(AssignmentCreateDto dto);
    List<Assignment> GetByCourse(int courseId);
}
