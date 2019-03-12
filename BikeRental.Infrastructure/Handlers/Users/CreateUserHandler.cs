using System;
using System.Threading.Tasks;
using BikeRental.Infrastructure.Commands;
using BikeRental.Infrastructure.Commands.Users;
using BikeRental.Infrastructure.Services;

namespace BikeRental.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email,
                command.Username, command.Password, command.Role);
        }
    }
}