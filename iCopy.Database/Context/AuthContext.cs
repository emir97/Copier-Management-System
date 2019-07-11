using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace iCopy.Database.Context
{
    public class AuthContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim,
        ApplicationUserRole, IdentityUserLogin<int>, ApplicationRoleClaim, IdentityUserToken<int>>
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var item in builder.Model.GetEntityTypes())
            {
                //Debugger.Launch();
                if (item.ClrType.GetProperty("CreatedDate") != null && item.ClrType.GetProperty("Active") != null)
                {
                    builder.Entity(item.ClrType).Property("Active").HasDefaultValue(true).HasDefaultValueSql("1").ValueGeneratedOnAdd();
                    builder.Entity(item.ClrType).Property("CreatedDate").HasDefaultValue(DateTime.Now).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                }
            }
            builder.Entity<ApplicationUser>().Property(x => x.ChangePassword).HasDefaultValue(true).HasDefaultValueSql("1").ValueGeneratedOnAdd();
            builder.Entity<ApplicationUser>().Property(x => x.LockoutEnabled).HasDefaultValue(true).HasDefaultValueSql("1").ValueGeneratedOnAdd();
        }
    }
}
