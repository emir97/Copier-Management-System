using System.Threading.Tasks;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class LoginController : Controller
    {
        private readonly IUserService UserService;
        private readonly IAuthenticationService AuthenticationService;

        public LoginController(IUserService userService, IAuthenticationService authenticationService)
        {
            this.UserService = userService;
            this.AuthenticationService = authenticationService;
        }
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
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
