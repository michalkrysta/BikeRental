using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BikeRental.Core.Domain;
using BikeRental.Core.Repositories;
using BikeRental.Infrastructure.DTO;
using BikeRental.Infrastructure.Exceptions;
using ErrorCodes = BikeRental.Infrastructure.Exceptions.ErrorCodes;

namespace BikeRental.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CustomerService(ICustomerRepository customerRepository,
            IUserRepository userRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> GetAsync(Guid userId)
        {
            var customer = await _customerRepository.GetAsync(userId);
            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<IEnumerable<CustomerDto>> BrowseAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
                throw new ServiceException(ErrorCodes.UserNotFound, $"User with user id: '{userId}' does not exist.");
            var customer = await _customerRepository.GetAsync(userId);
            if (customer != null)
                throw new ServiceException(ErrorCodes.CustomerAlreadyExists,
                    $"Customer with user id: '{userId}' already exists.");
            customer = new Customer(user);
            await _customerRepository.AddAsync(customer);
        }

        public async Task RentVehicle(Guid userId, string model, string name, string type)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var customer = await _customerRepository.GetAsync(userId);
            if (customer == null)
                return;
            await _customerRepository.DeleteAsync(customer);
        }
    }
}