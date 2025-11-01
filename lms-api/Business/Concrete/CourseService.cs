using LMS_API.Business.Abstract;
using LMS_API.Business.Mapper;
using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Business.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseService(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _courseDal.GetAllAsync();
            return courses.Select(c => CourseMapper.ToDto(c)).ToList();
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseDal.GetAsync(c => c.Id == id);
            return CourseMapper.ToDto(course);
        }

        public async Task AddAsync(CourseDto courseDto)
        {
            var entity = CourseMapper.ToEntity(courseDto);
            await _courseDal.AddAsync(entity);
        }

        public async Task UpdateAsync(CourseDto courseDto)
        {
            var entity = CourseMapper.ToEntity(courseDto);
            await _courseDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _courseDal.GetAsync(c => c.Id == id);
            if (entity != null)
            {
                await _courseDal.DeleteAsync(entity);
            }
        }
    }
}
