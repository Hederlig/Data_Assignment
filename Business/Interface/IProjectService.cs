using Business.Models;
using Business.Models.Dtos;

namespace Business.Interface
    {
    public interface IProjectService
        {
        Task AddAsync(ProjectCreate registrationForm);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Project project);
        }
    }