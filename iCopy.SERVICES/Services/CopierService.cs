﻿using AutoMapper;
using iCopy.Database.Context;
using iCopy.Model.Request;
using iCopy.SERVICES.Extensions;
using iCopy.SERVICES.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCopy.SERVICES.Services
{
    public class CopierService : CRUDService<Database.Copier, Model.Request.Copier, Model.Request.Copier, Model.Response.Copier, Model.Request.CopierSearch, int>, ICopierService
    {
        private readonly AuthContext auth;
        private readonly IUserService UserService;
        private readonly IProfilePhotoService ProfilePhotoService;

        public CopierService(
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

        public override async Task<Model.Response.Copier> GetByIdAsync(int id)
        {
            return mapper.Map<Model.Response.Copier>(await ctx.Copiers.Include(x => x.City).ThenInclude(x => x.Country).FirstOrDefaultAsync(x => x.ID == id));
        }

        public override async Task<List<Model.Response.Copier>> TakeRecordsByNumberAsync(int take = 15)
        {
            List<Model.Response.Copier> items = mapper.Map<List<Model.Response.Copier>>(await ctx.Copiers.Include(x => x.City).ToListAsync());
            return items;
        }

        public override async Task<Tuple<List<Model.Response.Copier>, int>> GetByParametersAsync(CopierSearch search, string order, string nameOfColumnOrder, int start, int length)
        {
            var query = ctx.Copiers
                .Include(x => x.City)
                .AsQueryable();
            if (search.Active != null)
                query = query.Where(x => x.Active == search.Active);
            if (search.CityID!= null)
                query = query.Where(x => x.CityId == search.CityID);
            if (search.CountryID != null)
                query = query.Where(x => x.City.CountryID == search.CountryID);
     
            if (nameof(Database.Copier.ID) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.ID, order);
            else if (nameof(Database.Copier.Name) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.Name, order);
            else if (nameof(Database.Copier.PhoneNumber) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.PhoneNumber, order);
            else if (nameof(Database.Copier.CityId) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.City.Name, order);

            var data = mapper.Map<List<Model.Response.Copier>>(await query.Skip(start).Take(length).ToListAsync());
            return new Tuple<List<Model.Response.Copier>, int>(data, await query.CountAsync());
        }

        public override async Task<Model.Response.Copier> DeleteAsync(int id)
        {
            Database.Copier copier = await ctx.Copiers.FindAsync(id);
            try
            {
                IEnumerable<Database.ApplicationUserProfilePhoto> copierProfile = await ctx.ApplicationUserProfilePhotos.Where(x => x.ApplicationUserId == copier.ApplicationUserId).ToListAsync();
                IEnumerable<Database.ProfilePhoto> profilePhotos = await ctx.ProfilePhotos.Where(x => copierProfile.Any(y => y.ProfilePhotoId == x.ID)).ToListAsync();
                if (copierProfile != null)
                {
                    ctx.ApplicationUserProfilePhotos.RemoveRange(copierProfile);
                    await ctx.SaveChangesAsync();
                }

                if (profilePhotos != null)
                {
                    ctx.ProfilePhotos.RemoveRange(profilePhotos);
                    await ctx.SaveChangesAsync();
                }
                ctx.Copiers.Remove(copier);
                await ctx.SaveChangesAsync();
                await UserService.DeleteAsync(copier.ApplicationUserId);
                // TODO: Dodati log operaciju
            }
            catch (Exception e)
            {
                //TODO: Dodati log operaciju
                throw e;
            }

            return mapper.Map<Model.Response.Copier>(copier);
        }

        public override async Task<Model.Response.Copier> InsertAsync(Model.Request.Copier entity)
        {
            Database.Copier model = mapper.Map<Database.Copier>(entity);
            try
            {
                Model.Response.ApplicationUser user = await UserService.InsertAsync(mapper.Map<Model.Request.ApplicationUser>(entity.User), Model.Enum.Enum.Roles.Copier);
                model.ApplicationUserId = user.ID;
                ctx.Copiers.Add(model);
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

            return mapper.Map<Model.Response.Copier>(model);
        }
    }
}