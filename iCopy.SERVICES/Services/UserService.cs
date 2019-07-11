using AutoMapper;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.Database.Context;
using iCopy.SERVICES.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationUser = iCopy.Database.ApplicationUser;
using Enum = iCopy.Model.Enum.Enum;

namespace iCopy.SERVICES.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly AuthContext context;
        private readonly IPasswordHasher<Database.ApplicationUser> PasswordHasher;
        private readonly IUserValidator<Database.ApplicationUser> UserValidator;
        private readonly UserManager<Database.ApplicationUser> UserManager;

        public UserService(
            AuthContext ctx, 
            IMapper mapper, 
            IPasswordHasher<Database.ApplicationUser> PasswordHasher,
            IUserValidator<Database.ApplicationUser> UserValidator,
            UserManager<Database.ApplicationUser> UserManager)
        {
            this.mapper = mapper;
            this.context = ctx;
            this.PasswordHasher = PasswordHasher;
            this.UserValidator = UserValidator;
            this.UserManager = UserManager;
        }

        public Task<LoginResult> Login(Login login)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<Model.Response.ApplicationUser> DeleteAsync(int id)
        {
            Database.ApplicationUser model = await context.Users.FindAsync(id);
            List<Database.ApplicationUserClaim> claims = await context.UserClaims.Where(x => x.UserId == model.Id).ToListAsync();
            List<Database.ApplicationUserRole> roles = await context.UserRoles.Where(x => x.UserId == model.Id).ToListAsync();
            List<IdentityUserLogin<int>> logins = await context.UserLogins.Where(x => x.UserId == model.Id).ToListAsync();
            List<IdentityUserToken<int>> tokens = await context.UserTokens.Where(x => x.UserId == model.Id).ToListAsync();
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (tokens != null)
                    {
                        context.UserTokens.RemoveRange(tokens);
                        await context.SaveChangesAsync();
                    }
                    if (logins != null)
                    {
                        context.UserLogins.RemoveRange(logins);
                        await context.SaveChangesAsync();
                    }
                    if (claims != null)
                    {
                        context.UserClaims.RemoveRange(claims);
                        await context.SaveChangesAsync();
                    }
                    context.UserRoles.RemoveRange(roles);
                    await context.SaveChangesAsync();
                    context.Users.Remove(model);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                }
                // TODO: Dodati log u bazu
                catch (Exception e)
                {
                    transaction.Rollback();
                    //  TODO: Dodati log u bazu
                    throw e;
                }
            }
            return mapper.Map<Model.Response.ApplicationUser>(model);
        }

        public async Task<Model.Response.ApplicationUser> InsertAsync(Model.Request.ApplicationUser user, params Enum.Roles[]  roles) 
        {
            UserValidator<Database.ApplicationUser> aa = new UserValidator<ApplicationUser>();
            Database.ApplicationUser model = mapper.Map<Database.ApplicationUser>(user);
            using (IDbContextTransaction transaction = context.Database.CurrentTransaction ?? await context.Database.BeginTransactionAsync())
            {
                try
                {
                    IdentityResult result = await UserValidator.ValidateAsync(UserManager, model);
                    model.PasswordHash = PasswordHasher.HashPassword(model, user.Password);
                    context.Users.Add(model);
                    await context.SaveChangesAsync();
                    foreach (var item in roles)
                    {
                        Database.ApplicationRole role = await context.Roles.FirstOrDefaultAsync(x => x.Name == item.ToString());
                        context.Add(new Database.ApplicationUserRole() {RoleId = role.Id, UserId = model.Id});
                        await context.SaveChangesAsync();
                    }

                    transaction.Commit();
                    // TODO: Dodati log operaciju
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    // TODO Dodati log operaciju
                    throw e;
                }
            }
            return mapper.Map<Model.Response.ApplicationUser>(model);
        }
    }

}
