using LMS_API.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_API.Business.Abstract
{
    public interface IInstructorService
    {
        Task<List<Instructor>> GetAllAsync();
        Task<Instructor> GetByIdAsync(int id);
        Task AddAsync(Instructor instructor);
        Task UpdateAsync(Instructor instructor);
        Task DeleteAsync(int id);
    }
}
