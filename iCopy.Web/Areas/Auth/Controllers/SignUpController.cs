using System;
using System.Threading.Tasks;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.SERVICES.Services;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class SignUpController : Controller
    {
        private readonly IClientService ClientService;

        public SignUpController(IClientService ClientService)
        {
            this.ClientService = ClientService;
        }
        [HttpGet]
        public Task<ViewResult> Index() => Task.FromResult(View(new Model.Request.Client()));
        [HttpPost, AutoValidateModelState]
        public async Task<IActionResult> Index([FromForm] Model.Request.Client client)
        {
            try
            {

            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
