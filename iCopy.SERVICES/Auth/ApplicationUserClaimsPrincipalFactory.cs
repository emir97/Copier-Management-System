using System.Security.Claims;
using System.Threading.Tasks;
using iCopy.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace iCopy.SERVICES.Auth
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Database.ApplicationUser, Database.ApplicationRole>, IUserClaimsPrincipalFactory<Database.ApplicationUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);


            return identity;
        }
    }
}
