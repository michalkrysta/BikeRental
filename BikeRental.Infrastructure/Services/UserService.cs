using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRental.Core.Domain;
using BikeRental.Core.Repositories;
using BikeRental.Infrastructure.DTO;

namespace BikeRental.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                FullName = user.FullName
            };
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = users.Select(x => new UserDto
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                Role = x.Role,
                FullName = x.FullName
            });

            return usersDto;
        }

        public async Task RegisterAsync(Guid userId, string email,
            string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
                throw new Exception($"User with email: '{email}' already exists.");
            //var salt = _encrypter.GetSalt(password);
            //var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, username, role, password, "salt");
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
                throw new Exception("Invalid credentials");
            //var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == password)
                return;
            throw new Exception("Invalid credentials");
        }
    }
}