using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace iCopy.Web.Areas.Administration.Controllers
{
    [Area(Strings.Area.Administration)]
    public class CopierController : BaseDataTableCRUDController<Model.Request.Copier, Model.Request.Copier, Model.Response.Copier, Model.Request.CopierSearch, int>
    {
        private new readonly ICopierService crudService;

        private Model.Request.ProfilePhoto PhotoSession => HttpContext.Session.Get<Model.Request.ProfilePhoto>(Session.Keys.Upload.ProfileImage);

        public CopierController(ICopierService CrudService, SharedResource _localizer, IMapper mapper) : base(CrudService, _localizer, mapper)
        {
            this.crudService = CrudService;
        }

        [HttpPost, Transaction, AutoValidateModelState]
        public override async Task<IActionResult> Insert(Copier model)
        {
            try
            {
                model.ProfilePhoto = PhotoSession;
                model.CompanyId = 1;
                await crudService.InsertAsync(model);
                TempData["success"] = _localizer.SuccAdd;
                return Ok();
            }
            catch (Exception e)
            {
                return Json(new { success = false, error = e.Message });
            }
        }

        [HttpPost, Transaction]
        public override async Task<IActionResult> Update(int id, [FromForm]Copier model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await crudService.UpdateAsync(id, model);
                    TempData["success"] = _localizer.SuccUpdate;
                    return RedirectToAction(nameof(Update));
                }
                catch
                {
                    TempData["error"] = _localizer.ErrUpdate;
                }
            }

            return View(await crudService.GetByIdAsync(id));
        }
    }
}
