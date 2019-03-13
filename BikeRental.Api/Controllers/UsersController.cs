using System.Threading.Tasks;
using BikeRental.Infrastructure.Commands;
using BikeRental.Infrastructure.Commands.Users;
using BikeRental.Infrastructure.Services;
using BikeRental.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly GeneralSettings _generalSettings;
        private readonly IUserService _userService;

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher, GeneralSettings generalSettings) : base(commandDispatcher)
        {
            _userService = userService;
            _generalSettings = generalSettings;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var setting = _generalSettings.Name;
            var users = await _userService.BrowseAsync();
            return Json(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await DispatchAsync(command);
            return Created($"users/{command.Email}", null);
        }
    }
}