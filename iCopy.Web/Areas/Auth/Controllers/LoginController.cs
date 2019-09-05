using System.Linq;
using System.Threading.Tasks;
using iCopy.Database;
using iCopy.Database.Context;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.IServices;
using iCopy.Web.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class LoginController : Controller
    {
        private readonly IUserService UserService;
        private readonly IAuthenticationService AuthenticationService;
        private DBContext context;

        public LoginController(IUserService userService, IAuthenticationService authenticationService, DBContext context)
        {
            this.UserService = userService;
            this.context = context;
            this.AuthenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                LoginResult result = await UserService.Login(login);
                if (result.Success)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.ClaimsPrincipal);
                    return Redirect(Settings.Routes.Dashboard);
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

        public async Task<string> Test()
        {
            Database.ApplicationUser user = new Database.ApplicationUser() {Id = 2};

            var name = await context.Companies
                .Select(x => x.Name)
                .Union(await context.Copiers.Where(x => x.ApplicationUserId == user.Id && x.Active).Select(x => x.Name).ToListAsync())
                .Union(await context.Clients.Include(x => x.Person).Select(x => x.Person.FirstName + " " + x.Person.LastName).ToListAsync())
                .Union(await context.Employees.Include(x => x.Person).Select(x => x.Person.FirstName + " " + x.Person.LastName).ToListAsync())
                .FirstOrDefaultAsync();
            return name;
        }
    }
}
