using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.IServices;
using iCopy.SERVICES.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace iCopy.SERVICES.Registers
{
    public static class iCopyServiceRegister
    {
        public static IServiceCollection AddiCopyServices(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddScoped<ICRUDService<Model.Request.Country, Model.Request.Country, Model.Response.Country, Model.Request.CountrySearch, int>,
                CountryService>();
            services.AddScoped<IReadService<Model.Response.Country, Model.Request.CountrySearch, int>, CountryService>();
            services.AddScoped<IReadService<Model.Response.City, Model.Request.CitySearch, int>, CityService>();
            services.AddScoped<ICRUDService<Model.Request.City, Model.Request.City, Model.Response.City, Model.Request.CitySearch, int>,
                CityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICopierService, CopierService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfilePhotoService, ProfilePhotoService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
