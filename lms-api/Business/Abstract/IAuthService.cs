using Entity.Concrete;

namespace LMS_API.Business.Abstract;

public interface IAuthService
{
    User Register(string fullName,string email,string password);
    User Login(string email,string password);

    bool UserExists(string email);
}
