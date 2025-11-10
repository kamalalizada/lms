using LMS_API.Business.Abstract;
using LMS_API.DataAccess.Concrete.EntityFramework;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Business.Concrete
{
    public class InstructorDashboardService : IInstructorDashboardService
    {
        private readonly LMSContext _context;

        public InstructorDashboardService(LMSContext context)
        {
            _context = context;
        }

        public async Task<InstructorDashboardDto> GetDashboard(int instructorId)
        {
            // Instructor-a aid kursları və əlaqəli məlumatları çəkirik
            var courses = await _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .Include(c => c.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                .Include(c => c.Modules)
                    .ThenInclude(m => m.Lessons)
                .ToListAsync();

            var courseItems = new List<CourseDashboardItemDto>();
            int totalStudents = 0;
            int totalPending = 0;

            foreach (var course in courses)
            {
                int pendingSub = await _context.Submissions
                    .Where(s => s.CourseId == course.Id && s.Grade == null)
                    .CountAsync();

                int studentCount = course.StudentCourses.Count;

                courseItems.Add(new CourseDashboardItemDto
                {
                    Id = course.Id,
                    Title = course.Title,
                    Students = studentCount,
                    Modules = course.Modules.Count,
                    Lessons = course.Modules.Sum(m => m.Lessons.Count),
                    PendingSubmissions = pendingSub
                });

                totalStudents += studentCount;
                totalPending += pendingSub;
            }

            return new InstructorDashboardDto
            {
                TotalCourses = courses.Count,
                TotalStudents = totalStudents,
                PendingSubmissions = totalPending,
                Courses = courseItems
            };
        }
    }
}
