using AutoMapper;
using iCopy.SERVICES.Context;
using iCopy.SERVICES.IServices;

namespace iCopy.SERVICES.Services
{
    public class CompanyService : CRUDService<Database.Company, Model.Request.Company, Model.Request.Company, Model.Response.Company, Model.Request.CompanySearch, int>, ICompanyService
    {
        public CompanyService(DBContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
