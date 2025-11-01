using LMS_API.DataAccess.Interfaces;
using LMS_API.Entity.Concrete;

namespace LMS_API.DataAccess.Concrete.EntityFramework;

public interface ISubmissionDal:IEntityRepository<Submission>
{
}
