using Entity.Concrete;
using LMS_API.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, LMSContext>, IUserDal
    {
        public EfUserDal(LMSContext context) : base(context)
        {
        }


        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetByRoleAsync(string role)
        {
            return await _context.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }
    }
}
