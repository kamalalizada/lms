using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

public interface IAssignmentService
{
    Task Create(AssignmentCreateDto dto);
    Task Update(AssignmentUpdateDto dto);
    Task Delete(int id);
    Task<Assignment> GetById(int id);
    Task<List<Assignment>> GetByCourse(int courseId);
}
