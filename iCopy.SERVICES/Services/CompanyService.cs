using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iCopy.Model.Request;
using iCopy.SERVICES.Context;
using iCopy.SERVICES.Extensions;
using iCopy.SERVICES.IServices;
using Microsoft.EntityFrameworkCore;
using Company = iCopy.Model.Response.Company;

namespace iCopy.SERVICES.Services
{
    public class CompanyService : CRUDService<Database.Company, Model.Request.Company, Model.Request.Company, Model.Response.Company, Model.Request.CompanySearch, int>, ICompanyService
    {
        private AuthContext auth;
        public CompanyService(DBContext ctx, IMapper mapper, AuthContext auth) : base(ctx, mapper)
        {
            this.auth = auth;
        }

        public override async Task<List<Company>> TakeRecordsByNumberAsync(int take = 15)
        {
            List<Company> items = mapper.Map<List<Model.Response.Company>>(await ctx.Companies.Include(x => x.City).ToListAsync());
            items.ForEach(async x => mapper.Map(await auth.Users.FindAsync(x.ApplicationUserId), x));
            return items;
        }

        public override async Task<Tuple<List<Company>, int>> GetByParametersAsync(CompanySearch search, string order, string nameOfColumnOrder, int start, int length)
        {
            var query = ctx.Companies
                .Include(x => x.City)
                .AsQueryable();
            if (search.Active != null)
                query = query.Where(x => x.Active == search.Active);
            if (search.CityID != null)
                query = query.Where(x => x.CityId == search.CityID);
            if (search.CountryID != null)
                query = query.Where(x => x.City.CountryID == search.CountryID);
            if (!string.IsNullOrWhiteSpace(search.Address))
                query = query.Where(x => x.Address.Contains(search.Address, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(search.ContactAgent))
                query = query.Where(x => x.ContactAgent.Contains(search.ContactAgent, StringComparison.CurrentCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name, StringComparison.CurrentCultureIgnoreCase));

            if (nameof(Database.Company.ID) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.ID, order);
            else if (nameof(Database.Company.Name) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.Name, order);
            else if (nameof(Database.Company.ContactAgent) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.ContactAgent, order);
            else if (nameof(Database.Company.PhoneNumber) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.PhoneNumber, order);
            else if (nameof(Database.Company.CityId) == nameOfColumnOrder)
                query = query.OrderByAscDesc(x => x.City.Name, order);

            var data = mapper.Map<List<Model.Response.Company>>(await query.Skip(start).Take(length).ToListAsync());
            data.ForEach(async x => mapper.Map(await auth.Users.FindAsync(x.ApplicationUserId), x));

            return new Tuple<List<Company>, int>(data, await query.CountAsync());
        }
    }
}
