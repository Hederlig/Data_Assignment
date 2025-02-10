using Data.Contexts;

namespace Data.Repositories;

public class StatusTypeEntity(DataContext context)
{
    private readonly DataContext _context = context;
}
