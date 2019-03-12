using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeRental.Infrastructure.DTO;

namespace BikeRental.Infrastructure.Services
{
    public interface ICustomerService : IService
    {
        Task<CustomerDto> GetAsync(Guid userId);
        Task<IEnumerable<CustomerDto>> BrowseAsync();
        Task CreateAsync(Guid userId);
        Task RentVehicle(Guid userId, string model, string name, string type);
        Task DeleteAsync(Guid userId);
    }
}