using Entity.Concrete;
using LMS_API.Business.Abstract;
using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;

namespace LMS_API.Business.Concrete;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentDal _enrollmentDal;
    private readonly ICourseDal _courseDal;

    public EnrollmentService(IEnrollmentDal enrollmentDal, ICourseDal courseDal)
    {
        _enrollmentDal = enrollmentDal;
        _courseDal = courseDal;
    }

    public async Task Enroll(int studentId, int courseId)
    {
        var exists = await _enrollmentDal.GetAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        if (exists != null)
            return;

        await _enrollmentDal.AddAsync(new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId
        });
    }

    public async Task Unenroll(int studentId, int courseId)
    {
        var data = await _enrollmentDal.GetAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        if (data != null)
            await _enrollmentDal.DeleteAsync(data);
    }

    public async Task<List<Course>> GetStudentCourses(int studentId)
    {
        var enrollments = await _enrollmentDal.GetAllAsync();
        var courseIds = enrollments
            .Where(e => e.StudentId == studentId)
            .Select(e => e.CourseId)
            .ToList();

        var courses = await _courseDal.GetAllAsync();
        return courses.Where(c => courseIds.Contains(c.Id)).ToList();
    }
}

