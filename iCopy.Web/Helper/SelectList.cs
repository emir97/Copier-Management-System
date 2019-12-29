using System;
using AutoMapper;
using iCopy.Database.Context;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using static iCopy.Model.Enum.Enum;
using iCopy.Database;

namespace iCopy.Web.Helper
{
    public class SelectList : ISelectList
    {
        private readonly SharedResource SharedResource;
        private readonly Constants constants;
        private readonly DBContext context;
        private readonly IMapper mapper;

        public SelectList(
            SharedResource SharedResource,
            Constants constants,
            DBContext context,
            IMapper mapper
            )
        {
            this.mapper = mapper;
            this.SharedResource = SharedResource;
            this.constants = constants;
            this.context = context;
        }
        public IEnumerable<SelectListItem> BaseSelectListItem(bool includeChooseText, string chooseText, IEnumerable<SelectListItem> selectListItems)
        {
            var items = new List<SelectListItem>();
            if (includeChooseText)
                items.Add(new SelectListItem { Text = chooseText, Value = string.Empty });
            if(selectListItems != null)
                items.AddRange(selectListItems);
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> Countries(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCountry, mapper.Map<List<SelectListItem>>(await context.Countries.Where(x => x.Active).ToListAsync()));
        }

        public async Task<IEnumerable<SelectListItem>> Cities(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, mapper.Map<List<SelectListItem>>(await context.Cities.Where(x => x.Active).ToListAsync()));
        }

        public async Task<IEnumerable<SelectListItem>> Cities(int countryId, bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, mapper.Map<List<SelectListItem>>(await context.Cities.Where(x => x.Active && x.CountryID == countryId).ToListAsync()));
        }

        public async Task<IEnumerable<SelectListItem>> Copiers(int companyId, bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCopier, mapper.Map<List<SelectListItem>>(await context.Copiers.Where(x => x.Active && x.CompanyId == companyId).ToListAsync()));
        }

        public async Task<IEnumerable<SelectListItem>> Copiers(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCopier, mapper.Map<List<SelectListItem>>(await context.Copiers.Where(x => x.Active).ToListAsync()));
        }

        public async Task<IEnumerable<SelectListItem>> CitiesByCityCountryId(int cityId, bool includeChooseText = true)
        {
            var countryId = (await context.Cities.FindAsync(cityId))?.CountryID;
            if(countryId.HasValue)
                return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, mapper.Map<List<SelectListItem>>(await context.Cities.Where(x => x.Active && x.CountryID == countryId).ToListAsync()));
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCity, null);
        }

        public async Task<IEnumerable<SelectListItem>> Companies(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCompany, mapper.Map<List<SelectListItem>>(await context.Companies.Where(x => x.Active).ToListAsync()));
        }

        public async Task<IEnumerable<SelectListItem>> Companies(int companyId, bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChooseCompany, mapper.Map<List<SelectListItem>>(await context.Companies.Where(x => x.Active && x.ID == companyId).ToListAsync()));
        }

        public Task<IEnumerable<SelectListItem>> Genders(bool includeChooseText = true)
        {
            return Task.FromResult(BaseSelectListItem(includeChooseText, SharedResource.ChooseGender, constants.Genders.Zip(
                Enum.GetNames(typeof(Database.Gender)),
                (s, s1) => new SelectListItem(s, s1))));
        }

        public async Task<IEnumerable<SelectListItem>> PrintPagesOptions(bool includeChooseText = true)
        {
            return BaseSelectListItem(includeChooseText, SharedResource.ChoosePrintOptions, Enum.GetValues(typeof(PrintPagesOptions)).Cast<PrintPagesOptions>().Select(x => new SelectListItem
            {
                Text = SharedResource.LocalizedString(x.ToString()),
                Value = ((int)x).ToString()
            }));
        }
    }
}
