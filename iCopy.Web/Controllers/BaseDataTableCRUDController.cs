using iCopy.SERVICES.IServices;
using iCopy.Web.Models;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iCopy.Web.Controllers
{
    public class BaseDataTableCRUDController<TInsert, TUpdate, TResult, TSearch, TPk> : Controller where TSearch : class where TInsert : class, new()
    {
        protected readonly ICRUDService<TInsert, TUpdate, TResult, TSearch, TPk> crudService;
        private readonly SharedResource _localizer;

        public BaseDataTableCRUDController(ICRUDService<TInsert, TUpdate, TResult, TSearch, TPk> crudService, SharedResource _localizer)
        {
            this.crudService = crudService;
            this._localizer = _localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int numberOfRecords = await crudService.GetNumberOfRecords();
            DataTable<TResult> model = new DataTable<TResult>()
            {
                recordsFiltered = numberOfRecords,
                recordsTotal = numberOfRecords,
                data = await crudService.TakeRecordsByNumber(15)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Insert() => PartialView("_Add", new TInsert());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(TInsert model)
        {
            if(ModelState.IsValid)
            {
                await crudService.InsertAsync(model);
                return Json(new { success = true, message = _localizer.SuccAdd });
            }
            return PartialView("_Add", model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(TPk id)
        {
            TResult model = await crudService.GetByIdAsync(id);
            if (model != null)
                return PartialView("_Edit", model);
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TPk id, [FromForm]TUpdate model)
        {
            if (ModelState.IsValid)
            {
                await crudService.UpdateAsync(id, model);
                return Json(new { success = true, message = _localizer.SuccUpdate });
            }
            return PartialView("_Edit", model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(TPk id)
        {
            try
            {
                await crudService.DeleteAsync(id);
                return Json(new { success = true, message = _localizer.SuccDelete });
            }
            catch
            {
                return Json(new { success = false, message = _localizer.ErrDelete });
            }
        }
    }
}
