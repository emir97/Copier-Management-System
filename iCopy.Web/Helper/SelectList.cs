using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using iCopy.Model.Request;
using iCopy.Model.Response;
using iCopy.SERVICES.IServices;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iCopy.Web.Helper
{
    public class SelectList : ISelectList
    {
        private readonly SharedResource SharedResource;
        private readonly IReadService<Model.Response.Country, CountrySearch, int> CountryReadService;

        public SelectList(
            SharedResource SharedResource,
            IReadService<Model.Response.Country, Model.Request.CountrySearch, int> CountryReadService
            )
        {
            this.SharedResource = SharedResource;
            this.CountryReadService = CountryReadService;
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
    }
}
