using LMS_API.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_API.Business.Abstract
{
    public interface IEnrollmentService
    {
        Task Enroll(int studentId, int courseId);
        Task Unenroll(int studentId, int courseId);
        Task<List<Course>> GetStudentCourses(int studentId);
    }
}
