using AutoMapper;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.Exceptions;
using iCopy.SERVICES.IServices;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace iCopy.Web.Areas.Administration.Controllers
{
    [Area(Strings.Area.Administration)]
    public class UserController : Controller
    {
        private readonly SharedResource _localizer;
        private readonly IUserService CrudService;
        private readonly ValidationErrors _validationErrors;

        public UserController(IUserService CrudService, SharedResource _localizer, IMapper mapper, ValidationErrors _validationErrors)
        {
            this.CrudService = CrudService;
            this._localizer = _localizer;
            this._validationErrors = _validationErrors;
        }

        [HttpPost, Transaction, AutoValidateModelState]
        public async Task<IActionResult> UpdatePassword(int id, [FromForm] Model.Request.ChangePassword model)
        {
            try
            {
                await CrudService.UpdatePassword(id, model);
                return Json(new { success = true, message = _localizer.SuccPasswordUpdated });
            }
            catch (ModelStateException e)
            {
                ModelState.AddModelError(e.Key, _localizer.LocalizedString(e.Message));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", _localizer.ErrUpdatePassword);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
        }

        [HttpPost, Transaction, AutoValidateModelState]
        public async Task<IActionResult> Update(int id, Model.Request.ApplicationUserUpdate model)
        {
            try
            {
                await CrudService.UpdateAsync(id, model);
                return Json(new {success = true, message = _localizer.SuccUserUpdate});
            }
            catch (ModelStateException e)
            {
                ModelState.AddModelError(e.Key, _validationErrors.LocalizedString(e.Message));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", _localizer.ErrUserUpdate);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
        }
    }
}
