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
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task RegisterAsync(Guid userId, string email,
            string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
                throw new ServiceException(ErrorCodes.EmailInUse, $"User with email: '{email}' already exists.");
            //var salt = _encrypter.GetSalt(password);
            //var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, username, role, password, "salt");
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
                throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
            //var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == password)
                return;
            throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
        }
    }
}