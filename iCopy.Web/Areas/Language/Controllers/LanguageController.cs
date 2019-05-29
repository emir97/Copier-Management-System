using iCopy.Web.Helper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace iCopy.Web.Areas.Language.Controllers
{
    [Area("Language")]
    public class LanguageController : Controller
    {
        public IActionResult Change(string culture, string redirectUrl)
        {
            if (!string.IsNullOrWhiteSpace(culture) && Localization.SupportedCultures.Any(x => x.Name == culture))
            {
                CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                Response.Cookies.SetCultureInfoCookie(new RequestCulture(culture));
            }
            return Url.IsLocalUrl(redirectUrl) ? LocalRedirect(redirectUrl) : LocalRedirect("~/");
        }
    }
}