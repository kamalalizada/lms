using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;

namespace LMS_API.DataAccess.Concrete.EntityFramework;

public class EfInstructorDal : EfEntityRepositoryBase<Instructor, LMSContext>, IInstructorDal
{
    public EfInstructorDal(LMSContext context) : base(context)
    {
    }
}
