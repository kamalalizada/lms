using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_API.Business.Abstract
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
        Task AddAsync(CourseDto courseDto);
        Task UpdateAsync(CourseDto courseDto);
        Task DeleteAsync(int id);
    }
}
