using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iCopy.Web.Helper
{
    public interface ISelectList
    {
        Task<IEnumerable<SelectListItem>> Countries(bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Cities(bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Cities(int countryId, bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Copiers(int companyId, bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Copiers(bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> CitiesByCityCountryId(int cityId, bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Companies(bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Companies(int companyId, bool includeChooseText = true);
        Task<IEnumerable<SelectListItem>> Genders(bool includeChooseText = true);
    }
}
