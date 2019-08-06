using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iCopy.SERVICES.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Country, Model.Response.Country>().ReverseMap();
            CreateMap<Database.Country, Model.Request.Country>().ReverseMap();
            CreateMap<Model.Response.Country, Model.Request.Country>().ReverseMap();
            CreateMap<Database.City, Model.Response.City>().ReverseMap();
            CreateMap<Database.City, Model.Request.City>().ReverseMap();
            CreateMap<Model.Response.City, Model.Request.City>().ReverseMap();
            CreateMap<Database.Company, Model.Response.Company>().ReverseMap();
            CreateMap<Database.Company, Model.Request.Company>().ReverseMap();
            CreateMap<Model.Response.Company, Model.Request.Company>().ReverseMap();
            CreateMap<Database.Copier, Model.Response.Copier>().ReverseMap();
            CreateMap<Database.Copier, Model.Request.Copier>().ReverseMap();
            CreateMap<Model.Response.Copier, Model.Request.Copier>().ReverseMap();

            CreateMap<Model.Response.Company, Model.Request.Company>().ReverseMap();
            CreateMap<Database.Country, SelectListItem>()
                .ForMember(x => x.Text, y => y.MapFrom(c => c.Name))
                .ForMember(x => x.Value, y => y.MapFrom<string>(c => c.ID.ToString()))
                .ReverseMap();
            CreateMap<Database.City, SelectListItem>()
                .ForMember(x => x.Text, y => y.MapFrom(c => c.Name))
                .ForMember(x => x.Value, y => y.MapFrom(c => c.ID.ToString()))
                .ReverseMap();
            CreateMap<Database.Company, SelectListItem>()
                .ForMember(x => x.Text, y => y.MapFrom(c => c.Name))
                .ForMember(x => x.Value, y => y.MapFrom(c => c.ID.ToString()))
                .ReverseMap();
            CreateMap<Database.ProfilePhoto, Model.Response.ProfilePhoto>().ReverseMap();
            CreateMap<Database.ProfilePhoto, Model.Request.ProfilePhoto>().ReverseMap();
            CreateMap<Database.ApplicationUser, Model.Request.ApplicationUser>()
                .ReverseMap()
                .ForMember(x => x.NormalizedUserName, opt => opt.MapFrom(y => y.Username.ToUpper()))
                .ForMember(x => x.NormalizedEmail, opt => opt.MapFrom(y => y.Email.ToUpper()))
                .ForMember(x => x.SecurityStamp, opt => Guid.NewGuid().ToString());
            CreateMap<Database.ApplicationUser, Model.Response.ApplicationUser>().ReverseMap();
        }
    }
}
