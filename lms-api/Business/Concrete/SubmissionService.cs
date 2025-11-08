using LMS_API.Business.Abstract;
using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;

namespace Business.Concrete
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionDal _submissionDal;
        private readonly IAssignmentDal _assignmentDal;
        private readonly IEnrollmentDal _enrollmentDal;

        private readonly string[] allowedTypes =
        {
            "application/pdf",
            "application/zip",
            "image/jpeg",
            "image/png"
        };

        public SubmissionService(
            ISubmissionDal submissionDal,
            IAssignmentDal assignmentDal,
            IEnrollmentDal enrollmentDal)
        {
            _submissionDal = submissionDal;
            _assignmentDal = assignmentDal;
            _enrollmentDal = enrollmentDal;
        }

        public async Task SubmissionAsync(SubmissionCreateDto dto)
        {
            var assignment = await _assignmentDal.GetAsync(a => a.Id == dto.AssignmentId);
            if (assignment == null)
                throw new Exception("Assignment not found");

            var enrolled = await _enrollmentDal.GetAsync(e =>
                e.StudentId == dto.StudentId &&
                e.CourseId == assignment.CourseId);

            if (enrolled == null)
                throw new Exception("Student is not enrolled in this course");

            if (dto.FilePath == null || dto.FilePath.Length == 0)
                throw new Exception("File is required");

            if (!allowedTypes.Contains(dto.FilePath.ContentType))
                throw new Exception("Invalid file type. Allowed: PDF / ZIP / JPG / PNG");

            if (dto.FilePath.Length > 10 * 1024 * 1024)
                throw new Exception("File is too large (max 10MB)");

            var folder = Path.Combine("wwwroot", "submissions");
            Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid() + Path.GetExtension(dto.FilePath.FileName);
            string filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await dto.FilePath.CopyToAsync(stream);

            var submission = new Submission
            {
                AssignmentId = dto.AssignmentId,
                StudentId = dto.StudentId,
                FilePath = "/submissions/" + fileName,
                SubmittedAt = DateTime.Now,
                Status = "Submitted"
            };

            await _submissionDal.AddAsync(submission);
        }

        public async Task Grade(int id, GradeDto dto)
        {
            var submission = await _submissionDal.GetAsync(s => s.Id == id);
            if (submission == null)
                throw new Exception("Submission not found");

            submission.Grade = dto.Grade;
            submission.Feedback = dto.Feedback;
            submission.Status = "Graded";

            await _submissionDal.UpdateAsync(submission);
        }

        public async Task<List<Submission>> GetSubmissionByAssignment(int assignmentId)
        {
            var all = await _submissionDal.GetAllAsync();
            return all.Where(s => s.AssignmentId == assignmentId).ToList();
        }

        public async Task<List<Submission>> GetSubmissionByStudent(int studentId)
        {
            var all = await _submissionDal.GetAllAsync();
            return all.Where(s => s.StudentId == studentId).ToList();
        }

        public async Task<int> CountPending(int assignmentId)
        {
            var all = await _submissionDal.GetAllAsync();
            return all.Count(s =>
                s.AssignmentId == assignmentId &&
                s.Status == "Submitted" &&
                s.Grade == null
            );
        }

        public async Task<int> CountLate(int assignmentId)
        {
            var all = await _submissionDal.GetAllAsync();
            return all.Count(s =>
                s.AssignmentId == assignmentId &&
                s.SubmittedAt > s.Assignment.DueDate
            );
        }

        public async Task<int> CountOnTime(int assignmentId)
        {
            var all = await _submissionDal.GetAllAsync();
            return all.Count(s =>
                s.AssignmentId == assignmentId &&
                s.SubmittedAt <= s.Assignment.DueDate
            );
        }

        public async Task<SubmissionStatsDto> GetStats(int assignmentId)
        {
            return new SubmissionStatsDto
            {
                Pending = await CountPending(assignmentId),
                Late = await CountLate(assignmentId),
                OnTime = await CountOnTime(assignmentId)
            };
        }

    }
}
