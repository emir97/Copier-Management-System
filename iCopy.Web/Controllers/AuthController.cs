using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> User;
        public AuthController(SignInManager<IdentityUser> user)
        {
            this.User = user;
        }
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(int a)
        {
           
        }
    }
}
