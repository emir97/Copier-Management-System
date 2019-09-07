using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using iCopy.Database.Context;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.Exceptions;
using iCopy.SERVICES.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ApplicationUser = iCopy.Database.ApplicationUser;

namespace iCopy.SERVICES.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthContext authContext;
        private readonly IPasswordHasher<ApplicationUser> PasswordHasher;
        private readonly DBContext dbContext;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> ClaimsPrincipalFactory;

        public AuthenticationService(
            AuthContext authContext, 
            IPasswordHasher<Database.ApplicationUser> PasswordHasher,
            DBContext dbContext,
            IUserClaimsPrincipalFactory<Database.ApplicationUser> ClaimsPrincipalFactory
            )
        {
            this.authContext = authContext;
            this.PasswordHasher = PasswordHasher;
            this.dbContext = dbContext;
            this.ClaimsPrincipalFactory = ClaimsPrincipalFactory;
        }
        public async Task<LoginResult> Authenticate(Login login)
        {
                Database.ApplicationUser user = await authContext.Users.SingleOrDefaultAsync(x => x.UserName == login.Username || x.Email == login.Username);
                if (user == null)
                    throw new ModelStateException(nameof(login), string.Format((IFormatProvider)CultureInfo.CurrentCulture, "User is not active"));
                if (!user.Active && user.LockoutEnd < DateTime.Now)
                    throw new ModelStateException(nameof(login), "User is not active");
                if (PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password) != PasswordVerificationResult.Success)
                    throw new ModelStateException(nameof(login), "Wrong password");

                Database.Company c = await dbContext.Companies.FirstOrDefaultAsync(x => x.ApplicationUserId == user.Id && x.Active);


                ClaimsPrincipal principal = await ClaimsPrincipalFactory.CreateAsync(user);


                return new LoginResult()
                {
                    Success = true,
                    ClaimsPrincipal = principal
                };
            }
    }
}
