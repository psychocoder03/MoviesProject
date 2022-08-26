using Microsoft.AspNetCore.Mvc;
using MoviesProj.Models.User;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await authenticationService.userExists(user.Email))
                return BadRequest("User with this email already exists.");
            await authenticationService.RegisterUser(user);
            //}
            return StatusCode(201);
        }
        [HttpPost("login")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthentication user)
        {
            if (!await authenticationService.ValidateUser(user))
                return Unauthorized();
            return Ok(new
            {
                Token = await authenticationService.CreateToken()
            });
        }
    }
}
