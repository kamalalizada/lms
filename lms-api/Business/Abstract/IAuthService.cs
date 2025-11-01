using Entity.Concrete;
using System.Threading.Tasks;

namespace LMS_API.Business.Abstract
{
    public interface IAuthService
    {
        Task<User> Register(string fullName, string email, string password);
        Task<User?> Login(string email, string password);
        Task<bool> UserExists(string email);
        string CreateToken(User user);
    }
}
