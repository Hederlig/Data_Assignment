using Castle.Core.Resource;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
    {
    //public async Task<IEnumerable<CustomerEntity>> GetCustomersWithOrdersAsync()
    //{
        //return await _db.Include(c => c.Projects).ToListAsync();
    //}
}