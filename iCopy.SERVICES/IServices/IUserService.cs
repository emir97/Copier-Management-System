using iCopy.Model.Request;
using iCopy.Model.Response;
using System.Threading.Tasks;

namespace iCopy.SERVICES.IServices
{
    public interface IUserService
    {
        Task<LoginResult> Login(Login login);
    }
}
