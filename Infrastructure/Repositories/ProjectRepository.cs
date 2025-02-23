using System.Linq.Expressions;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
    {
    private new readonly DataContext _context = context;

    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Projects
            .Include(p => p.Status)
            .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERRROR" + ex);
            return [];
        }
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entities = await _context.Projects
            .Where(expression)
            .Include(p => p.Status)
            .FirstOrDefaultAsync();

        return entities;
    }
}

