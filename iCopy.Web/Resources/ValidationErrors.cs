using Microsoft.Extensions.Localization;

namespace iCopy.Web.Resources
{
    public class ValidationErrors
    {
        private readonly IStringLocalizer<ValidationErrors> localizer;

        public ValidationErrors(IStringLocalizer<ValidationErrors> localizer)
        {
            this.localizer = localizer;
        }

    }
}
