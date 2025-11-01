using LMS_API.Business.Abstract;
using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_API.Business.Concrete
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorDal _instructorDal;

        public InstructorService(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _instructorDal.GetAllAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instructorDal.GetAsync(i => i.Id == id);
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _instructorDal.AddAsync(instructor);
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            await _instructorDal.UpdateAsync(instructor);
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _instructorDal.GetAsync(i => i.Id == id);
            if (instructor != null)
                await _instructorDal.DeleteAsync(instructor);
        }
    }
}
