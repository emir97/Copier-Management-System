using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Location.Controllers
{
    [Area("Location")]
    public class CityController : BaseDataTableCRUDController<Model.Request.City, Model.Request.City, Model.Response.City, Model.Request.CitySearch, int>
    {
        public CityController(ICRUDService<Model.Request.City, Model.Request.City, Model.Response.City, CitySearch, int> crudService,
            SharedResource _localizer, IMapper mapper) : base(crudService, _localizer, mapper)
        {
        }
    }
}
