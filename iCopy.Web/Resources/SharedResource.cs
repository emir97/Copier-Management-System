using Microsoft.Extensions.Localization;

namespace iCopy.Web
{
    public class SharedResource
    {
        private readonly IStringLocalizer<SharedResource> localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }

        public string SaveChanges => localizer["SaveChanges"];
        public string Close => localizer["Close"];
        public string Name => localizer["Name"];
        public string ShortName => localizer["ShortName"];
        public string PhoneCode => localizer["PhoneCode"];
        public string Active => localizer["Active"];
        public string Actions => localizer["Actions"];
        public string Search => localizer["Search"];
        public string Reset => localizer["Reset"];
        public string Inactive => localizer["Inactive"];
        public string All => localizer["All"];
        public string LocationSettings => localizer["LocationSettings"];
        public string Countries => localizer["Countries"];

        #region SuccMessage
        public string SuccUpdate => localizer["SuccUpdate"];
        public string SuccAdd => localizer["SuccAdd"];
        public string SuccDelete => localizer["SuccDelete"];
        #endregion

        #region ErrorMessage
        public string ErrDelete => localizer["ErrDelete"];
        #endregion

        #region Country
        public string AddCountry => localizer["AddCountry"];
        public string CountrySettings => localizer["CountrySettings"];
        #endregion
    }
}
