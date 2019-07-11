using System.Collections.Generic;
using System.Threading.Tasks;
using iCopy.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iCopy.Web.Controllers
{
    public class SelectListItemController : Controller
    {
        private readonly ISelectList SelectList;

        public SelectListItemController(ISelectList SelectList)
        {
            this.SelectList = SelectList;
        }

        public async Task<List<SelectListItem>> Cities(int? id)
        {
            if (id.HasValue) return await SelectList.Cities(id.Value);
            return await SelectList.Cities();
        }
    }
}
