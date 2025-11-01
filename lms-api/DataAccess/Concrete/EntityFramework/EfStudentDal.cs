using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;

namespace LMS_API.DataAccess.Concrete.EntityFramework;

public class EfStudentDal : EfEntityRepositoryBase<Student, LMSContext>, IStudentDal
{
    public EfStudentDal(LMSContext context) : base(context)
    {
    }
}
