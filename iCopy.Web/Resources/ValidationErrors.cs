using Microsoft.Extensions.Localization;

namespace iCopy.Web
{
    public class ValidationErrors
    {
        private readonly IStringLocalizer<ValidationErrors> Localizer;

        public ValidationErrors(IStringLocalizer<ValidationErrors> Loclizer)
        {
            this.Localizer = Localizer;
        }

    }
}
