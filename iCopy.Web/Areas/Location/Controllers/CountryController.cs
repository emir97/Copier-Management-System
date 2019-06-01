using AutoMapper;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Location.Controllers
{
    [Area("Location")]
    public class CountryController : BaseDataTableCRUDController<Model.Request.Country, Model.Request.Country, Model.Response.Country, Model.Request.CountrySearch, int>
    {
        public CountryController(ICRUDService<Model.Request.Country, Model.Request.Country, Model.Response.Country, Model.Request.CountrySearch, int> crudService, 
            SharedResource _localizer, IMapper mapper) : base(crudService, _localizer, mapper)
        {
        }

    }
}