using Microsoft.AspNetCore.Mvc;

namespace iCopy.Web.Areas.Administration.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
