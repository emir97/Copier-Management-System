using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.Web.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IAuthenticationService = iCopy.SERVICES.IServices.IAuthenticationService;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService AuthenticationService;

        public LoginController(IAuthenticationService AuthenticationService)
        {
            this.AuthenticationService = AuthenticationService;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                LoginResult result = await AuthenticationService.Authenticate(login);
                if (result.Success)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.ClaimsPrincipal);
                    return Redirect(Settings.Routes.Dashboard.Index);
                }
                ModelState.AddModelError("InvalidLogin", result.Error);
            }
            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }
    }
}
