using AutoMapper;
using iCopy.SERVICES.IServices;
using iCopy.SERVICES.Services;
using Microsoft.Extensions.DependencyInjection;

namespace iCopy.SERVICES.Registers
{
    public static class iCopyServiceRegister
    {
        public static IServiceCollection AddiCopyServices(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddScoped<ICRUDService<Model.Request.Country, Model.Request.Country, Model.Response.Country, Model.Request.CountrySearch, int>,
                CRUDService<Database.Country, Model.Request.Country, Model.Request.Country, Model.Response.Country, Model.Request.CountrySearch, int>>();
            return services;
        }
    }
}
