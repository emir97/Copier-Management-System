using iCopy.Model.Request;
using iCopy.Model.Response;
using System.Threading.Tasks;

namespace iCopy.SERVICES.IServices
{
    public interface IUserService
    {
        Task<LoginResult> Login(Login login);
        Task<Model.Response.ApplicationUser> DeleteAsync(int id);
        Task<Model.Response.ApplicationUser> InsertAsync(Model.Request.ApplicationUser user, params Model.Enum.Enum.Roles[] roles);
    }
}
