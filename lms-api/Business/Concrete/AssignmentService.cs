using LMS_API.Business.Abstract;
using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Concrete;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentDal _assignmentDal;

    public AssignmentService(IAssignmentDal assignmentDal)
    {
        _assignmentDal = assignmentDal;
    }

    public async Task Create(AssignmentCreateDto dto)
    {
        var entity = new Assignment
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            CourseId = dto.CourseId,
        };

        await _assignmentDal.AddAsync(entity);
    }

    public async Task<Assignment> GetById(int id)
    {
        return await _assignmentDal.GetAsync(a => a.Id == id);
    }

    public async Task<List<Assignment>> GetByCourse(int courseId)
    {
        var all = await _assignmentDal.GetAllAsync();
        return all.Where(a => a.CourseId == courseId).ToList();
    }

    public async Task Update(AssignmentUpdateDto dto)
    {
        var entity = await _assignmentDal.GetAsync(a => a.Id == dto.Id);
        if (entity == null)
            throw new Exception("Assignment not found");

        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.DueDate = dto.DueDate;

        await _assignmentDal.UpdateAsync(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _assignmentDal.GetAsync(a => a.Id == id);
        if (entity == null)
            throw new Exception("Assignment not found");

        await _assignmentDal.DeleteAsync(entity);
    }
}
