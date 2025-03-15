using Main.Classes.UserRegistrationHelper;
using Main.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;

namespace Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistration _userRegistration;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRegistration userRegistration, ILogger<UserController> logger)
        {
            _userRegistration = userRegistration;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Response>> Register(UserValidateBody body)
        {
            _logger.LogInformation("Main -> UserController -> Register");

            Response response = await _userRegistration.Register(body);

            return Ok(response);
        }
    }
}
