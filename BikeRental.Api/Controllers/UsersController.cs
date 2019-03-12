using System.Threading.Tasks;
using BikeRental.Infrastructure.Repositories;
using BikeRental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();

            return Json(users);
        }
    }
}