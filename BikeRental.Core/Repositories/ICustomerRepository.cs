using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRental.Core.Domain;

namespace BikeRental.Core.Repositories
{
    public interface ICustomerRepository : IRepository
    {
        Task<Customer> GetAsync(Guid userId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}