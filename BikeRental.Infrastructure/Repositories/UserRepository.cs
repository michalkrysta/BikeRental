using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRental.Core.Domain;
using BikeRental.Core.Repositories;

namespace BikeRental.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> Users = new HashSet<User>
        {
            new User(Guid.NewGuid(), "user1@email.com", "user1", "admin", "secret", "salt"),
            new User(Guid.NewGuid(), "user2@email.com", "user2", "admin", "secret", "salt"),
            new User(Guid.NewGuid(), "user3@email.com", "user3", "admin", "secret", "salt")
        };

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(Users.FirstOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(Users.FirstOrDefault(x => x.Email == email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(Users);

        public async Task AddAsync(User user)
        {
            Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            Users.Remove(user);
            await Task.CompletedTask;
        }
    }
}