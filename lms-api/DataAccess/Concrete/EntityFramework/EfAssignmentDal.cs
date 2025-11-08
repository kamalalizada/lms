using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;

namespace LMS_API.DataAccess.Concrete.EntityFramework;

public class EfAssignmentDal : EfEntityRepositoryBase<Assignment, LMSContext>, IAssignmentDal
{
    public EfAssignmentDal(LMSContext context) : base(context)
    {
    }
}
