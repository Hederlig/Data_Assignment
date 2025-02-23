
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ActivityStatusRepository(DataContext context) : BaseRepository<ActivityStatusEntity>(context), IActivityStatusRepository
    {
        
    }
