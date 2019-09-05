using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iCopy.Database;
using iCopy.Database.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace iCopy.SERVICES.Auth
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Database.ApplicationUser, Database.ApplicationRole>
    {
        private readonly DBContext context;

        public ApplicationUserClaimsPrincipalFactory(DBContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            this.context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var name = await context.Companies
                .Select(x => x.Name)
                .Union(await context.Copiers.Where(x => x.ApplicationUserId == user.Id && x.Active).Select(x => x.Name).ToListAsync())
                .Union(await context.Clients.Include(x => x.Person).Select(x => x.Person.FirstName + " " + x.Person.LastName).ToListAsync())
                .Union(await context.Employees.Include(x => x.Person).Select(x => x.Person.FirstName + " " + x.Person.LastName).ToListAsync())
                .FirstOrDefaultAsync();

            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));
            
            return identity;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            return new ClaimsPrincipal(await GenerateClaimsAsync(user));
        }

    }
}
