using iCopy.Web.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace iCopy.Web.Areas.Language.Controllers
{
    [Area("Language")]
    public class LanguageController : Controller
    {

        public IActionResult Change(string culture, string redirectUrl)
        {
            if (!string.IsNullOrWhiteSpace(culture))
            {
                CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                Response.Cookies.SetCultureInfoCookie(new RequestCulture(culture));
            }
            return Url.IsLocalUrl(redirectUrl) ? LocalRedirect(redirectUrl) : LocalRedirect("~/");
        }
    }
}