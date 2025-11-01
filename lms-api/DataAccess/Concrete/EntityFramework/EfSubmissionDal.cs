using LMS_API.Entity.Concrete;

namespace LMS_API.DataAccess.Concrete.EntityFramework;

public class EfSubmissionDal : EfEntityRepositoryBase<Submission, LMSContext>, ISubmissionDal
{
    public EfSubmissionDal(LMSContext context) : base(context)
    {
    }
}
