using System.Linq.Expressions;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
    {
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _db = context.Set<TEntity>();

    public virtual async Task AddAsync(TEntity entity)
        {
        await _db.AddAsync(entity);
        await _context.SaveChangesAsync();
        }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var entities = await _db.ToListAsync();
                return entities ?? [];
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return [];
            }
        }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _db.FirstOrDefaultAsync(expression);
            return entity;
        }

    public async Task UpdateAsync(TEntity entity)
        {
            _db.Update(entity);
            await _context.SaveChangesAsync();
        }

    public async Task RemoveAsync(TEntity entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

    public async Task<bool> ExistsAsync(TEntity entity)
        {
        var result = await _db.FindAsync(entity);

        if (result != null)
            return true;

        return false;
        }
    }