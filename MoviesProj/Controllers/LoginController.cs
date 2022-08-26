//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MoviesProj.Models.User;
//using MoviesProj.Services;

//namespace MoviesProj.Controllers
//{
//    public class LoginController : Controller
//    {
//        private readonly IUserService userService;
//        public LoginController(IUserService userService)
//        {
//            this.userService = userService;
//        }

//        [AllowAnonymous]
//        [Route("authenticate")]
//        [HttpPost]
//        public ActionResult Login([FromBody] User user)
//        {
//            var token = userService.Authenticate(user.Email, user.Password);
//            if (token == null)
//                return Unauthorized();
//            return Ok(new { token, user });
//        }
//    }
//}
