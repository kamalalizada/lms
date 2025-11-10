using LMS_API.Entity.Dto;
using System.Threading.Tasks;

namespace LMS_API.Business.Abstract
{
    public interface IInstructorDashboardService
    {
        Task<InstructorDashboardDto> GetDashboard(int instructorId);
    }
}
