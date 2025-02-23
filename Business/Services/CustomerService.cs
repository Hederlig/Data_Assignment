using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Business.Services;

public class CustomerService(CustomerRepository customerRepository)
    {
    private readonly CustomerRepository _customerRepository = customerRepository;

    //public async Task<IEnumerable<CustomerEntity>> GetCustomersWithOrdersAsync()
    //    {
    //    return await _customerRepository.GetCustomersWithOrdersAsync();
    //    }
    //public async Task AddCustomerAsync(CustomerEntity customer)
    //    {
    //    await _customerRepository.AddAsync(customer);
    //    }
    }