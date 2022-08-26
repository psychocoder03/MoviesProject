//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MoviesProj.Models.User;
//using MoviesProj.Services;

//namespace MoviesProj.Controllers
//{
//    [Authorize]
//    [AutoValidateAntiforgeryToken]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : Controller
//    {
//        private readonly IUserService userService;

//        public UserController(IUserService userService)
//        {
//            this.userService = userService;
//        }

//        // GET: UserController
//        [HttpGet]
//        public async Task<ActionResult> Index(int pageNo = 1)
//        {
//            return Ok(await userService.Get(pageNo));
//        }

//        // GET: UserController/Details/5
//        [HttpGet("{id:length(24)}")]
//        public async Task<ActionResult> Details(string id)
//        {
//            var user = await userService.Get(id);
//            if (user == null)
//                return NotFound($"User with Id {id} not found.");
//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Create(User user)
//        {
//            if (!ModelState.IsValid)
//                return UnprocessableEntity(ModelState);
//            return Ok(await userService.Create(user));
//        }



//        //private readonly UserManager<User> userManager;

//        //public UserController(UserManager<ApplicationUser> userManager)
//        //{
//        //    this.userManager = userManager;
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> Create(User user)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        ApplicationUser appUser = new ApplicationUser
//        //        {
//        //            UserName = user.Name,
//        //            Email = user.Email
//        //        };

//        //        IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
//        //        if (result.Succeeded)
//        //            ViewBag.Message = "User Created Successfully";
//        //        else
//        //        {
//        //            foreach (IdentityError error in result.Errors)
//        //                ModelState.AddModelError("", error.Description);
//        //        }
//        //    }
//        //    return View(user);
//        //}
//    }
//}
