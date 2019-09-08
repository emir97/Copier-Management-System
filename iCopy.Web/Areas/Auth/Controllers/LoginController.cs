using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.Web.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iCopy.SERVICES.Exceptions;
using iCopy.Web.Resources;
using IAuthenticationService = iCopy.SERVICES.IServices.IAuthenticationService;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService AuthenticationService;
        private readonly SharedResource _localizer;

        public LoginController(IAuthenticationService AuthenticationService, SharedResource _localizer)
        {
            this.AuthenticationService = AuthenticationService;
            this._localizer = _localizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                Redirect(Settings.Routes.Dashboard.Index);
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoginResult result = await AuthenticationService.Authenticate(login);
                    if (result.Success)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.ClaimsPrincipal);
                        return Redirect(Settings.Routes.Dashboard.Index);
                    }
                }
                catch (ModelStateException e)
                {
                    TempData["error"] = _localizer.LocalizedString(e.Message);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }
    }
}
