using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.Extensions;
using iCopy.SERVICES.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iCopy.Database.Context;
using Company = iCopy.Model.Response.Company;

namespace iCopy.SERVICES.Services
{
    public class CompanyService : CRUDService<Database.Company, Model.Request.Company, Model.Request.Company, Model.Response.Company, Model.Request.CompanySearch, int>, ICompanyService
    {
        private readonly AuthContext auth;
        private readonly IUserService UserService;
        private readonly IProfilePhotoService ProfilePhotoService;

        public CompanyService(
            DBContext ctx,
            IMapper mapper,
            AuthContext auth,
            IUserService UserService,
            IProfilePhotoService ProfilePhotoService) : base(ctx, mapper)
        {
            this.auth = auth;
            this.UserService = UserService;
            this.ProfilePhotoService = ProfilePhotoService;
        }

        public override async Task<Company> GetByIdAsync(int id)
        {
            return mapper.Map<Model.Response.Company>(await ctx.Companies.Include(x => x.City).ThenInclude(x => x.Country).FirstOrDefaultAsync(x => x.ID == id));
        }

        public override async Task<List<Company>> TakeRecordsByNumberAsync(int take = 15)
        {
            List<Company> items = mapper.Map<List<Model.Response.Company>>(await ctx.Companies.Include(x => x.City).ToListAsync());
            items.ForEach(x => mapper.Map(auth.Users.Find(x.ApplicationUserId), x));
            return items;
        }

        public override async Task<Tuple<List<Company>, int>> GetByParametersAsync(CompanySearch search, string order, string nameOfColumnOrder, int start, int length)
        {
            var query = ctx.Companies
                .Include(x => x.City)
                .AsQueryable();
            if (search.Active != null)
                query = query.Where(x => x.Active == search.Active);
            if (search.CityID != null)
                query = query.Where(x => x.CityId == search.CityID);
            if (search.CountryID != null)
                query = query.Where(x => x.City.CountryID == search.CountryID);
            if (!string.IsNullOrWhiteSpace(search.Address))
                query = query.Where(x => x.Address.Contains(search.Address, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(search.ContactAgent))
                query = query.Where(x => x.ContactAgent.Contains(search.ContactAgent, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name, StringComparison.CurrentCultureIgnoreCase));

            if (nameof(Database.Company.ID) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.ID, order);
            else if (nameof(Database.Company.Name) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.Name, order);
            else if (nameof(Database.Company.ContactAgent) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.ContactAgent, order);
            else if (nameof(Database.Company.PhoneNumber) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.PhoneNumber, order);
            else if (nameof(Database.Company.CityId) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.City.Name, order);

            var data = mapper.Map<List<Model.Response.Company>>(await query.Skip(start).Take(length).ToListAsync());
            data.ForEach(x => mapper.Map(auth.Users.Find(x.ApplicationUserId), x));

            return new Tuple<List<Company>, int>(data, await query.CountAsync());
        }

        //public override async Task<Company> DeleteAsync(int id)
        //{
        //    Database.Company company = await ctx.Companies.FindAsync(id);
        //    using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            IEnumerable<Database.ApplicationUserProfilePhoto> companyProfile = await ctx.ApplicationUserProfilePhotos.Where(x => x.ApplicationUserId == company.).ToListAsync();
        //            IEnumerable<Database.ProfilePhoto> profilePhotos = await ctx.ProfilePhotos.Where(x => companyProfile.Any(y => y.ProfilePhotoId == x.ID)).ToListAsync();
        //            if (companyProfile != null)
        //            {
        //                ctx.ApplicationUserProfilePhotos.RemoveRange(companyProfile);
        //                await ctx.SaveChangesAsync();
        //            }

        //            if (profilePhotos != null)
        //            {
        //                ctx.ProfilePhotos.RemoveRange(profilePhotos);
        //                await ctx.SaveChangesAsync();
        //            }
        //            ctx.Companies.Remove(company);
        //            await ctx.SaveChangesAsync();
        //            await UserService.DeleteAsync(company.ApplicationUserId);
        //            transaction.Commit();
        //            // TODO: Dodati log operaciju
        //        }
        //        catch (Exception e)
        //        {
        //            //TODO: Dodati log operaciju
        //            transaction.Rollback();
        //            transaction.Dispose();
        //            throw e;
        //        }
        //    }

        //    return mapper.Map<Model.Response.Company>(company);
        //}

        public override async Task<Model.Response.Company> InsertAsync(Model.Request.Company entity)
        {
            Database.Company model = mapper.Map<Database.Company>(entity);
            try
            {
                Model.Response.ApplicationUser user = await UserService.InsertAsync(mapper.Map<Model.Request.ApplicationUser>(entity.User), Model.Enum.Enum.Roles.Company);
                model.ApplicationUserId = user.ID;
                entity.ProfilePhoto.ApplicationUserId = user.ID;
                ctx.Companies.Add(model);
                await ctx.SaveChangesAsync();
                if (entity.ProfilePhoto != null)
                    await ProfilePhotoService.InsertAsync(entity.ProfilePhoto);
            }
            catch (Exception e)
            {
                //TODO: Dodati log operaciju
                throw e;
            }

            return mapper.Map<Model.Response.Company>(model);
        }
    }
}
