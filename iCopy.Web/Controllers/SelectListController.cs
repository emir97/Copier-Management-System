using System.Collections.Generic;
using System.Threading.Tasks;
using iCopy.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iCopy.Web.Controllers
{
    public class SelectListController : Controller
    {
        public readonly ISelectList SelectList;

        public SelectListController(ISelectList SelectList)
        {
            this.SelectList = SelectList;
        }

        public async Task<List<SelectListItem>> Cities()
        {
            return await SelectList.Cities();
        }

        public async Task<List<SelectListItem>> CitiesByCountry(int id)
        {
            return await SelectList.Cities(id);
        }
    }
}
