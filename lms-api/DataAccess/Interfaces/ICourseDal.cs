using LMS_API.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LMS_API.DataAccess.Interfaces
{
    public interface ICourseDal
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetAsync(Expression<Func<Course, bool>> predicate);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);
    }
}
