using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, LMSContext>, ICourseDal
    {
        public EfCourseDal(LMSContext context) : base(context)
        {
        }

        public async Task<List<Course>> GetByInstructorIdAsync(string instructorId)
        {
            return await _context.Courses
                .Where(c => c.InstructorId == int.Parse(instructorId))
                .ToListAsync();
        }

        public async Task<Course?> GetWithStudentsAsync(int courseId)
        {
            return await _context.Courses
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == courseId);
        }
    }
}
