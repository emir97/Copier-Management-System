using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.Context;
using iCopy.SERVICES.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iCopy.SERVICES.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Database.ApplicationUser> UserManager;
        private readonly SignInManager<Database.ApplicationUser> SignInManager;
        private readonly AuthContext AuthContext;
        public UserService(
            UserManager<Database.ApplicationUser> userManager,
            SignInManager<Database.ApplicationUser> signInManager,
            AuthContext authContext)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.AuthContext = authContext;
        }
        public async Task<LoginResult> Login(Login login)
        {
            var loginResult = new LoginResult();
            Database.ApplicationUser user = await AuthContext.Users.SingleOrDefaultAsync(x => x.UserName == login.Username || x.Email == login.Username);
            SignInResult result = await SignInManager.CheckPasswordSignInAsync(user, login.Password, true);
            if(result.IsLockedOut)
                return  new LoginResult();
            if(result.IsLockedOut)
                return  new LoginResult();
            if(!result.Succeeded)
                return new LoginResult();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.AuthenticationMethod, CookieAuthenticationDefaults.AuthenticationScheme)
            };
            claims.AddRange(await AuthContext.UserRoles.Include(x => x.ApplicationRole).Select(x => new Claim(ClaimTypes.Role, x.ApplicationRole.Name)).ToListAsync());
            loginResult.Success = true;
            loginResult.ClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            return loginResult;
        }
    }

}
