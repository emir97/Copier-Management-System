using iCopy.Model.Request;
using iCopy.SERVICES.IServices;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using iCopy.Database.Context;
using Microsoft.EntityFrameworkCore;
using City = iCopy.Model.Response.City;

namespace iCopy.Web.Helper
{
    public class SelectList : ISelectList
    {
        private readonly SharedResource SharedResource;
        private readonly DBContext context;
        private readonly IMapper mapper;

        public SelectList(
            SharedResource SharedResource,
            DBContext context,
            IMapper mapper
            )
        {
            this.mapper = mapper;
            this.SharedResource = SharedResource;
            this.context = context;
        }
        public List<SelectListItem> BaseSelectListItem(bool includeChooseText, string chooseText, IEnumerable<SelectListItem> selectListItems)
        {
            var items = new List<SelectListItem>();
            if (includeChooseText)
                items.Add(new SelectListItem { Text = chooseText, Value = string.Empty });
            if(selectListItems != null)
                items.AddRange(selectListItems);
            return items;
        }

        public async Task<List<SelectListItem>> Countries(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCountry, mapper.Map<List<SelectListItem>>(await context.Countries.Where(x => x.Active).ToListAsync()));
        }

        public async Task<List<SelectListItem>> Cities(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, mapper.Map<List<SelectListItem>>(await context.Cities.Where(x => x.Active).ToListAsync()));
        }

        public async Task<List<SelectListItem>> Cities(int countryId, bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, mapper.Map<List<SelectListItem>>(await context.Cities.Where(x => x.Active && x.CountryID == countryId).ToListAsync()));
        }

        public async Task<List<SelectListItem>> CitiesByCityCountryId(int cityId, bool includeChooseText = true)
        {
            var countryId = (await context.Cities.FindAsync(cityId))?.CountryID;
            if(countryId.HasValue)
                return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, mapper.Map<List<SelectListItem>>(await context.Cities.Where(x => x.Active && x.CountryID == countryId).ToListAsync()));
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, null);
        }
    }
}
