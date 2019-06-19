using AutoMapper;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CompanyController : BaseDataTableCRUDController<Model.Request.Company, Model.Request.Company, Model.Response.Company, Model.Request.CompanySearch, int>
    {
        private readonly ICompanyService CrudService;

        public CompanyController(ICompanyService CrudService, SharedResource _localizer, IMapper mapper) : base(CrudService, _localizer, mapper)
        {
            this.CrudService = CrudService;
        }
    }
}
