using ecommerce.Core.DTO;
using ecommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Null");
            }

            AuthenticationResponse? response = await _userService.Register(registerRequest);

            if (response == null || response.sucess == false)
            {
                return BadRequest("Not good");
            }

            return Ok(response);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null)
            { return BadRequest("login details null"); }

            AuthenticationResponse? response = await _userService.Login(request);

            if (response == null) { return Unauthorized(); }

            return Ok(response);

        }

    }
}
