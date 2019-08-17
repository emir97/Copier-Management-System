using AutoMapper;
using iCopy.Database.Context;
using iCopy.SERVICES.IServices;

namespace iCopy.SERVICES.Services
{
    public class ClientService : CRUDService<Database.Client, Model.Request.Client, Model.Request.Client, Model.Response.Client, object, int>, IClientService
    {
        public ClientService(DBContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
