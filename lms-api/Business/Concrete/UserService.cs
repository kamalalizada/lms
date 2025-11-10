using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using LMS_API.DataAccess.Interfaces;

namespace LMS_API.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userDal.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userDal.GetAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _userDal.GetAsync(u => u.Id == id);
            if (existing != null)
                await _userDal.DeleteAsync(existing);
        }
    }
}
