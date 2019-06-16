using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CompanyController : BaseDataTableCRUDController<Model.Request.Company, Model.Request.Company, Model.Response.Company, Model.Request.CompanySearch, int>
    {
        private readonly ICompanyService crudService;

        public CompanyController(ICompanyService crudService, SharedResource _localizer, IMapper mapper) : base(crudService, _localizer, mapper)
        {
            this.crudService = crudService;
        }
    }
}
