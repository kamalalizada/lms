using Entity.Concrete;
using LMS_API.DataAccess.Interfaces;

namespace LMS_API.DataAccess.Concrete.EntityFramework;

public class EfEnrollmentDal : EfEntityRepositoryBase<Enrollment, LMSContext>, IEnrollmentDal
{
    public EfEnrollmentDal(LMSContext context) : base(context)
    {
    }
}
