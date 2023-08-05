using Marketplace.Api.Controllers.BaseControllers;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerApi
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> NewUser(NewUserInputModel input)
            => Return(await _userService.RegisterUserAsync(input));

    }
}
