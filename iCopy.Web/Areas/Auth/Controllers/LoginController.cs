using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.Exceptions;
using iCopy.SERVICES.IServices;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class LoginController : Controller
    {
        private readonly IUserService UserService;
        private readonly IAuthenticationService AuthenticationService;
        private readonly SharedResource _localizer;

        public LoginController(IUserService userService, IAuthenticationService authenticationService, SharedResource _localizer)
        {
            this.UserService = userService;
            this.AuthenticationService = authenticationService;
            this._localizer = _localizer;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoginResult result = await UserService.Login(login);
                    if (result.Success)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.ClaimsPrincipal);
                        return Redirect(Settings.Routes.Dashboard.Index);
                    }
                } catch(ModelStateException e)
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
