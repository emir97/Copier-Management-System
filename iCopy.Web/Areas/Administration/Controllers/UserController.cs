using AutoMapper;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iCopy.Web.Areas.Administration.Controllers
{
    [Area(Strings.Area.Administration)]
    public class UserController : Controller
    {
        private readonly SharedResource _localizer;
        private readonly IUserService CrudService;

        public UserController(IUserService CrudService, SharedResource _localizer, IMapper mapper)
        {
            this.CrudService = CrudService;
            this._localizer = _localizer;
        }
        [HttpPost, Transaction]
        public async Task<IActionResult> UpdatePassword(int id, [FromForm] Model.Request.ChangePassword model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                await CrudService.UpdatePassword(id, model);
                TempData["success"] = _localizer.SuccPasswordUpdated;
            }
            return LocalRedirect(Url.IsLocalUrl(returnUrl) ? returnUrl : "~/");
        }
    }
}
