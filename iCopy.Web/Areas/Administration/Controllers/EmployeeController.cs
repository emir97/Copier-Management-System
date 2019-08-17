using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.Web.Controllers;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iCopy.Web.Areas.Administration.Controllers
{
    [Area(Strings.Area.Administration)]
    public class EmployeeController : BaseDataTableCRUDController<Model.Request.Employee, Model.Request.Employee, Model.Response.Employee, Model.Request.EmployeeSearch, int>
    {
        private new readonly IEmployeeService crudService;

        private Model.Request.ProfilePhoto PhotoSession => HttpContext.Session.Get<Model.Request.ProfilePhoto>(Session.Keys.Upload.ProfileImage);

        public EmployeeController(IEmployeeService CrudService, SharedResource _localizer, IMapper mapper) : base(CrudService, _localizer, mapper)
        {
            crudService = CrudService;
        }

        [HttpPost, Transaction, AutoValidateModelState]
        public override async Task<IActionResult> Insert(Employee model)
        {
            try
            {
                model.ProfilePhoto = PhotoSession;
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
        public override async Task<IActionResult> Update(int id, [FromForm]Employee model)
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