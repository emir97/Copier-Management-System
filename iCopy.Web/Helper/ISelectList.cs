using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCopy.Web.Helper
{
    public interface ISelectList
    {
        Task<List<SelectListItem>> Countries(bool includeChooseText = true);
        Task<List<SelectListItem>> Cities(int? countryId = null, bool includeChooseText = true);
    }
}
