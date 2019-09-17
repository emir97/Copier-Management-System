using System;
using System.Text;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.Exceptions;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iCopy.SERVICES.IServices;
using iCopy.SERVICES.Services;
using IAuthenticationService = iCopy.SERVICES.IServices.IAuthenticationService;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth), AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService AuthenticationService;
        private readonly SharedResource _localizer;
        private readonly IDataProtector protector;
        private readonly IUserService UserService;

        public LoginController(IAuthenticationService AuthenticationService,
            SharedResource _localizer,
            IDataProtectionProvider dataProtectionProvider,
            IUserService UserService)
        {
            this.AuthenticationService = AuthenticationService;
            this._localizer = _localizer;
            this.protector = dataProtectionProvider.CreateProtector(Strings.Protection.UrlEncription);
            this.UserService = UserService;
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

        [HttpGet, Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Activate(string user, string token)
        {
            string decryptedUserId = Encoding.UTF8.GetString(protector.Unprotect(System.Web.HttpUtility.UrlDecodeToBytes(user)));
            string decryptedToken = Encoding.UTF8.GetString(protector.Unprotect(System.Web.HttpUtility.UrlDecodeToBytes(token)));

            if (int.TryParse(decryptedUserId, out int result) && await UserService.ActivateUserAccount(result, decryptedToken))
            {
                TempData["success"] = _localizer.UserAccountActivated;
            }
            else
            {
                TempData["error"] = _localizer.UserAccountNotActivated;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
