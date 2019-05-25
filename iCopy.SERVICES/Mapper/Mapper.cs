using AutoMapper;

namespace iCopy.SERVICES.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.City, Model.Response.City>().ReverseMap();
            CreateMap<Database.Country, Model.Response.Country>().ReverseMap();
            CreateMap<Database.Country, Model.Request.Country>().ReverseMap();
            CreateMap<Model.Response.Country, Model.Request.Country>().ReverseMap();
        }
    }
}
