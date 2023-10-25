using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserMvcApp.DTO;
using UserMvcApp.Models;
using UserMvcApp.Services;

namespace UserMvcApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationService _applicationService;
        public List<Error> ErrorArray { get; set; } = new(); 

        public UserController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal principal = HttpContext.User;

            if (principal.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignupDTO request)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        ErrorArray.Add(new Error("", error.ErrorMessage, ""));
                    }
                    ViewData["ErrorArray"] = ErrorArray;                    
                }
                return View();
            }

            try
            {
                await _applicationService.UserService.SignUpUserAsync(request);

            } catch (Exception e)
            {
                ErrorArray.Add(new Error("", e.Message, ""));
                ViewData["ErrorArray"] = ErrorArray;
                return View();
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO credentials)
        {
            var user = await _applicationService.UserService.LoginUserAsync(credentials);
            
            if (user == null)
            {
                ViewData["ValidateMessage"] = "Error: Username / Password invalid";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, credentials.Username!)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new()
            {
                AllowRefresh = true,
                IsPersistent = credentials.KeepLoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), properties);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUserAccountInfoAsync(UserPatchDTO request)
        {
            var user = await _applicationService.UserService.GetUserByUsername(request.Username!);

            await _applicationService.UserService.UpdateUserAccountInfoAsync(request, user!.Id);

            return RedirectToAction("Index", "Home");
        }

    }
}
