using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace iCopy.Web.Areas.Administration.Controllers
{

    [Area(Strings.Area.Administration)]
    public class CompanyController : BaseDataTableCRUDController<Model.Request.Company, Model.Request.Company, Model.Response.Company, Model.Request.CompanySearch, int>
    {

        private readonly ICompanyService CrudService;

        private Model.Request.ProfilePhoto PhotoSession => HttpContext.Session.Get<Model.Request.ProfilePhoto>(Session.Keys.Upload.ProfileImage);
        
        public CompanyController(ICompanyService CrudService, SharedResource _localizer, IMapper mapper) : base(CrudService, _localizer, mapper)
        {
            this.CrudService = CrudService;
        }

        [HttpGet]
        public override IActionResult Insert()
        {
            return View(new Model.Request.Company());
        }

        [HttpPost, ValidateAntiForgeryToken, Transaction]
        public override async Task<IActionResult> Insert(Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ProfilePhoto = PhotoSession;
                    await CrudService.InsertAsync(model);
                    return Ok();
                }
                catch(Exception e)
                {
                    return Json(new {success = false, error = e.Message});
                }
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
        }
    }
}
