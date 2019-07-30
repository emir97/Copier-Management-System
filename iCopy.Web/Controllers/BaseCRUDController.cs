using AutoMapper;
using iCopy.SERVICES.IServices;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using iCopy.SERVICES.Attributes;

namespace iCopy.Web.Controllers
{
    public class BaseCRUDController<TInsert, TUpdate, TResult, TSearch, TPk> : Controller where TSearch : class where TInsert : class, new()
    {
        protected readonly ICRUDService<TInsert, TUpdate, TResult, TSearch, TPk> crudService;
        protected readonly SharedResource _localizer;
        protected readonly IMapper mapper;

        public BaseCRUDController(ICRUDService<TInsert, TUpdate, TResult, TSearch, TPk> crudService, SharedResource _localizer, IMapper mapper)
        {
            this.crudService = crudService;
            this._localizer = _localizer;
            this.mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index() => View(await crudService.TakeRecordsByNumberAsync());

        [HttpGet]
        public virtual IActionResult Insert() => View(new TInsert());

        [HttpPost, Transaction]
        public virtual async Task<IActionResult> Insert(TInsert model)
        {
            if (ModelState.IsValid)
            {
                await crudService.InsertAsync(model);
                return Json(new { success = true, message = _localizer.SuccAdd });
            }
            return View(model);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Update(TPk id)
        {
            TResult model = await crudService.GetByIdAsync(id);
            if (model != null)
                return View(model);
            return NotFound();
        }

        [HttpPost, Transaction]
        public virtual async Task<IActionResult> Update(TPk id, [FromForm]TUpdate model)
        {
            if (ModelState.IsValid)
            {
                await crudService.UpdateAsync(id, model);
                return Json(new { success = true, message = _localizer.SuccUpdate });
            }
            return View(mapper.Map<TResult>(model));
        }

        [HttpGet, Transaction]
        public virtual async Task<IActionResult> Delete(TPk id)
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

        [HttpPost, IgnoreAntiforgeryToken]
        public virtual async Task<IActionResult> ChangeActiveStatus(TPk id)
        {
            try
            {
                await crudService.ChangeActiveStatusAsync(id);
                return Json(new { success = true, message = _localizer.SuccChangeStatus });
            }
            catch
            {
                return Json(new { success = false, message = _localizer.ErrChangeStatus });
            }
        }
    }
}