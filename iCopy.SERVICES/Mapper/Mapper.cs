using AutoMapper;

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
            CreateMap<Database.ApplicationUser, Model.Response.Company>()
                .ForMember(x => x.ID, y => y.Ignore())
                .ForMember(x => x.Active, options => options.Ignore());
        }
    }
}
