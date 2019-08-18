using System;
using System.Net;
using System.Threading.Tasks;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.SERVICES.Services;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class SignUpController : Controller
    {
        private readonly IClientService ClientService;
        private readonly SharedResource _localizer;

        public SignUpController(IClientService ClientService, SharedResource _localizer)
        {
            this.ClientService = ClientService;
            this._localizer = _localizer;
        }
        [HttpGet]
        public Task<ViewResult> Index() => Task.FromResult(View(new Model.Request.Client()));
        [HttpPost, Transaction, AutoValidateModelState]
        public async Task<IActionResult> Index([FromForm] Model.Request.Client client)
        {
            try
            {
                await ClientService.InsertAsync(client);
                return Json(new {success = true, message = _localizer.SuccRegister});
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }
    }
}
