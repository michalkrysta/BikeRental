﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRental.Core.Domain;
using BikeRental.Core.Repositories;
using BikeRental.Infrastructure.DTO;

namespace BikeRental.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public CustomerService(ICustomerRepository customerRepository,
            IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<CustomerDto> GetAsync(Guid userId)
        {
            var customer = await _customerRepository.GetAsync(userId);
            return new CustomerDto
            {
                Name = customer.Name,
                UserId = customer.UserId,
                UpdatedAt = customer.UpdatedAt,
                Bicycles = customer.Bicycles
            };
        }

        public async Task<IEnumerable<CustomerDto>> BrowseAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(customer => new CustomerDto
            {
                Name = customer.Name,
                UserId = customer.UserId,
                UpdatedAt = customer.UpdatedAt,
                Bicycles = customer.Bicycles
            });
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null) throw new Exception($"User with user id: '{userId}' does not exist.");
            var customer = await _customerRepository.GetAsync(userId);
            if (customer != null) throw new Exception($"Customer with user id: '{userId}' already exists.");
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