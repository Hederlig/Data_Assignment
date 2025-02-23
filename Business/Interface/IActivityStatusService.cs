using Business.Models.Dtos;

namespace Business.Interface
    {
    public interface IActivityStatusService
        {
        Task<IEnumerable<ActivityStatus>> GetActivityStatusesAsync();
        }
    }