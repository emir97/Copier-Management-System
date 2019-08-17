using AutoMapper;
using iCopy.Database.Context;
using iCopy.SERVICES.IServices;

namespace iCopy.SERVICES.Services
{
    public class PersonService : CRUDService<Database.Person, Model.Request.Person, Model.Request.Person, Model.Response.Person, object, int>, IPersonService
    {
        public PersonService(DBContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
