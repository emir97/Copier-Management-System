using System.Threading.Tasks;

namespace User.IServices
{
    public interface IUserService
    {
        Task<LoginResult> Login(UserLogin login);
    }
}
