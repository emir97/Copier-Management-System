using AutoMapper;
using iCopy.Database;
using iCopy.SERVICES.Attributes;
using iCopy.Database.Context;
using iCopy.SERVICES.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ProfilePhoto = iCopy.Model.Response.ProfilePhoto;

namespace iCopy.SERVICES.Services
{
    public class ProfilePhotoService : CRUDService<Database.ProfilePhoto, Model.Request.ProfilePhoto, Model.Request.ProfilePhoto, Model.Response.ProfilePhoto, object, int>, IProfilePhotoService
    {
        public ProfilePhotoService(DBContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override async Task<ProfilePhoto> InsertAsync(Model.Request.ProfilePhoto entity)
        {
            Database.ProfilePhoto model = mapper.Map<Database.ProfilePhoto>(entity);

                try
                {
                    ctx.ProfilePhotos.Add(model);
                    await ctx.SaveChangesAsync();

                    if (await ctx.ApplicationUserProfilePhotos.AnyAsync(x => x.Active))
                    {
                        var activeApplicationUserProfilePhoto = await ctx.ApplicationUserProfilePhotos.SingleOrDefaultAsync(x => x.Active);
                        activeApplicationUserProfilePhoto.Active = false;
                        ctx.Entry<ApplicationUserProfilePhoto>(activeApplicationUserProfilePhoto).State = EntityState.Modified;
                        await ctx.SaveChangesAsync();
                    }
                    var aplicationUserProfilePhoto = new ApplicationUserProfilePhoto()
                    {
                        ApplicationUserId =  entity.ApplicationUserId,
                        ProfilePhotoId =  model.ID
                    };
                    ctx.ApplicationUserProfilePhotos.Add(aplicationUserProfilePhoto);
                    await ctx.SaveChangesAsync();
                    // TODO: Dodati log operaciju
                }
                catch (Exception e)
                {

                    // TODO: Dodati log operaciju

                    throw e;
                }

            return mapper.Map<Model.Response.ProfilePhoto>(model);
        }
    }
}
