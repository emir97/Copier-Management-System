using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iCopy.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> User;
        private readonly IUserService UserService;
        private readonly IAuthenticationService AuthenticationService;

        public AuthController(SignInManager<IdentityUser> user, IUserService userService, IAuthenticationService authenticationService)
        {
            this.User = user;
            this.UserService = userService;
            this.AuthenticationService = authenticationService;
        }
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                LoginResult result = await UserService.Login(login);
                if (result.Success)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.ClaimsPrincipal);
                }
                ModelState.AddModelError("InvalidLogin", result.Error);
            }
            return View(login);
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
