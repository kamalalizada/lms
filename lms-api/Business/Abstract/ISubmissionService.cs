using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Abstract;

public interface ISubmissionService
{
    Task SubmissionAsync(SubmissionCreateDto dto);
    Task Grade(int submissionId, GradeDto dto);

    Task<List<Submission>> GetSubmissionByAssignment(int assignmentId);
    Task<List<Submission>> GetSubmissionByStudent(int studentId);

    Task<int> CountPending(int assignmentId);
    Task<int> CountLate(int assignmentId);
    Task<int> CountOnTime(int assignmentId);

    Task<SubmissionStatsDto> GetStats(int assignmentId);
}
