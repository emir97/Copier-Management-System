using iCopy.Model.Request;
using iCopy.SERVICES.IServices;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using City = iCopy.Model.Response.City;

namespace iCopy.Web.Helper
{
    public class SelectList : ISelectList
    {
        private readonly SharedResource SharedResource;
        private readonly IReadService<Model.Response.Country, CountrySearch, int> CountryReadService;
        private readonly IReadService<City, CitySearch, int> CityReadService;

        public SelectList(
            SharedResource SharedResource,
            IReadService<Model.Response.Country, Model.Request.CountrySearch, int> CountryReadService,
            IReadService<Model.Response.City, Model.Request.CitySearch, int> CityReadService
            )
        {
            this.SharedResource = SharedResource;
            this.CountryReadService = CountryReadService;
            this.CityReadService = CityReadService;
        }
        public List<SelectListItem> BaseSelectListItem(bool includeChooseText, string chooseText, IEnumerable<SelectListItem> selectListItems)
        {
            var items = new List<SelectListItem>();
            if (includeChooseText)
                items.Add(new SelectListItem { Text = chooseText, Value = string.Empty });
            items.AddRange(selectListItems);
            return items;
        }

        public async Task<List<SelectListItem>> Countries(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCountry, (await CountryReadService.GetAllActiveAsync()).Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }));
        }

        public async Task<List<SelectListItem>> Cities(int? countryId = null, bool includeChooseText = true)
        {
            var request = await CityReadService.GetByParametersAsync(new CitySearch() {Active = true, CountryID = countryId});
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, request.Select(x => new SelectListItem {Text = x.Name, Value = x.ID.ToString()}));
        }
    }
}
