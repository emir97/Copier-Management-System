using AutoMapper;
using iCopy.Database.Context;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.Exceptions;
using iCopy.SERVICES.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCopy.SERVICES.Services
{
    public class EmployeeService : CRUDService<Database.Employee, Model.Request.Employee, Model.Request.Employee, Model.Response.Employee, Model.Request.EmployeeSearch, int>, IEmployeeService
    {
        private readonly AuthContext auth;
        private readonly IUserService UserService;
        private readonly IProfilePhotoService ProfilePhotoService;
        private readonly IPasswordHasher<Database.ApplicationUser> PasswordHasher;

        public EmployeeService(DBContext ctx,
            IMapper mapper,
            AuthContext auth,
            IUserService UserService,
            IProfilePhotoService ProfilePhotoService,
            IPasswordHasher<Database.ApplicationUser> PasswordHasher) : base(ctx, mapper)
        {
            this.auth = auth;
            this.UserService = UserService;
            this.ProfilePhotoService = ProfilePhotoService;
            this.PasswordHasher = PasswordHasher;
        }

        public async Task<Model.Response.ApplicationUser> UpdatePassword(int applicationUserId, ChangePassword password)
        {
            Database.ApplicationUser user = await auth.Users.FindAsync(applicationUserId);
            if (PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password.CurrentPassword) != PasswordVerificationResult.Success)
                throw new ModelStateException(nameof(password.CurrentPassword), "Current password is not correct");
            user.PasswordHash = PasswordHasher.HashPassword(user, password.NewPassword);
            try
            {
                await auth.SaveChangesAsync();
                // TODO: Dodati log
            }
            catch (Exception e)
            {
                // TODO: Dodati log
                throw e;
            }
            return mapper.Map<Model.Response.ApplicationUser>(user);
        }

        public override async Task<Model.Response.Employee> GetByIdAsync(int id)
        {
            Model.Response.Employee employee = mapper.Map<Model.Response.Employee>(await ctx.Employees.Include(x => x.CopierId).FirstOrDefaultAsync(x => x.ID == id));
            employee.User = mapper.Map<Model.Response.ApplicationUser>(await auth.Users.FindAsync(employee.ApplicationUserId));
            return employee;
        }

        public override async Task<Model.Response.Employee> InsertAsync(Model.Request.Employee entity)
        {
            Database.Employee model = mapper.Map<Database.Employee>(entity);
            try
            {
                Model.Response.ApplicationUser user = await UserService.InsertAsync(entity.User, Model.Enum.Enum.Roles.Employee);
                model.ApplicationUserId = user.ID;
                ctx.Employees.Add(model);
                await ctx.SaveChangesAsync();
                if (entity.ProfilePhoto != null)
                {
                    entity.ProfilePhoto.ApplicationUserId = user.ID;
                    await ProfilePhotoService.InsertAsync(entity.ProfilePhoto);
                }
                // TODO: Dodati log operaciju
            }
            catch (Exception e)
            {
                //TODO: Dodati log operaciju
                throw e;
            }
            return mapper.Map<Model.Response.Employee>(model);
        }

        public override async Task<Model.Response.Employee> UpdateAsync(int id, Model.Request.Employee entity)
        {
            try
            {
                Model.Response.Employee employee = await base.UpdateAsync(id, entity);
                // TODO: Dodati Log
                return employee;
            }
            catch (Exception e)
            {
                // TODO: Dodati log
                throw e;
            }
        }

        public override async Task<Model.Response.Employee> DeleteAsync(int id)
        {
            Database.Employee employee = await ctx.Employees.FindAsync(id);
            try
            {
                IEnumerable<Database.ApplicationUserProfilePhoto> employeeProfile = await ctx.ApplicationUserProfilePhotos.Where(x => x.ApplicationUserId == employee.ApplicationUserId).ToListAsync();
                IEnumerable<Database.ProfilePhoto> profilePhotos = await ctx.ProfilePhotos.Where(x => employeeProfile.Any(y => y.ProfilePhotoId == x.ID)).ToListAsync();
                if (employeeProfile != null)
                {
                    ctx.ApplicationUserProfilePhotos.RemoveRange(employeeProfile);
                    await ctx.SaveChangesAsync();
                }

                if (profilePhotos != null)
                {
                    ctx.ProfilePhotos.RemoveRange(profilePhotos);
                    await ctx.SaveChangesAsync();
                }
                ctx.Employees.Remove(employee);
                await ctx.SaveChangesAsync();
                await UserService.DeleteAsync(employee.ApplicationUserId);
                // TODO: Dodati log operaciju
            }
            catch (Exception e)
            {
                //TODO: Dodati log operaciju
                throw e;
            }

            return mapper.Map<Model.Response.Employee>(employee);
        }

        public override async Task<List<Model.Response.Employee>> TakeRecordsByNumberAsync(int take = 15)
        {
            List<Model.Response.Employee> employee = mapper.Map<List<Model.Response.Employee>>(await ctx.Employees.Include(x => x.Person).Include(x => x.Copier).Take(take).ToListAsync());
            employee.ForEach(x => {
                x.User = mapper.Map<Model.Response.ApplicationUser>(auth.Users.Find(x.ApplicationUserId));
                x.ProfilePhoto = mapper.Map<Model.Response.ProfilePhoto>(ctx.ApplicationUserProfilePhotos.FirstOrDefault(y => y.ApplicationUserId == x.ApplicationUserId && y.Active)?.ProfilePhoto);
                } );
            return employee;
        }
    }
}
