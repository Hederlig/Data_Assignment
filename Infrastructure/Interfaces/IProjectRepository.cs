using System.Linq.Expressions;
using Infrastructure.Entities;

namespace Infrastructure.Interfaces
    {
    public interface IProjectRepository : IBaseRepository<ProjectEntity>
        {
        new Task<IEnumerable<ProjectEntity>> GetAllAsync();
        new Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression);
    }
    }