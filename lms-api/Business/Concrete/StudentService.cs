using LMS_API.Business.Abstract;
using LMS_API.DataAccess.Concrete.EntityFramework;
using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Business.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentDal _studentDal;
        private readonly LMSContext _context;

        public StudentService(IStudentDal studentDal, LMSContext context)
        {
            _studentDal = studentDal;
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentDal.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentDal.GetAsync(s => s.Id == id);
        }

        public async Task AddAsync(Student student)
        {
            await _studentDal.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentDal.UpdateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _studentDal.GetAsync(s => s.Id == id);
            if (student != null)
                await _studentDal.DeleteAsync(student);
        }

        // MANY-TO-MANY OPERATIONS

        public async Task<bool> AddCourseAsync(int studentId, int courseId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            if (student == null || course == null)
                return false;

            var exists = await _context.StudentCourses
                .AnyAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (exists)
                return false;

            await _context.StudentCourses.AddAsync(new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            });

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCourseAsync(int studentId, int courseId)
        {
            var relation = await _context.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (relation == null)
                return false;

            _context.StudentCourses.Remove(relation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetCoursesAsync(int studentId)
        {
            return await _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.Course)
                .ToListAsync();
        }
    }
}
