using LMS_API.Entity.Concrete;

namespace LMS_API.Business.Abstract
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);

        Task<bool> AddCourseAsync(int studentId, int courseId);
        Task<bool> RemoveCourseAsync(int studentId, int courseId);
        Task<List<Course>> GetCoursesAsync(int studentId);
    }
}
