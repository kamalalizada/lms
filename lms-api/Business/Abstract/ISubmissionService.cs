using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace LMS_API.Business.Abstract;

public interface ISubmissionService
{
    Task SubmissionAsync(SubmissionCreateDto dto);
    void Grade(int submissionId,GradeDto dto);
    List<Submission> GetSubmissionByAssignment(int assignmentId);
    List<Submission> GetSubmissionByStudent(int studentId);
}
