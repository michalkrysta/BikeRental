using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRental.Core.Domain;
using BikeRental.Core.Repositories;

namespace BikeRental.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly ISet<Customer> Customers = new HashSet<Customer>();

        public async Task<Customer> GetAsync(Guid userId)
            => await Task.FromResult(Customers.SingleOrDefault(x => x.UserId == userId));

        public async Task<IEnumerable<Customer>> GetAllAsync()
            => await Task.FromResult(Customers);

        public async Task AddAsync(Customer customer)
        {
            Customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Customer customer)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Customer customer)
        {
            Customers.Remove(customer);
            await Task.CompletedTask;
        }
    }
}