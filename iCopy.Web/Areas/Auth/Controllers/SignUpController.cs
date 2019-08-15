using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class SignUpController : Controller
    {
        public SignUpController()
        {
            
        }

        public Task<ViewResult> Index() => Task.FromResult(View(new Model.Request.Client()));
    }
}
