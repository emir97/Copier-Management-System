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
        public string Yes => localizer["Yes"];
        public string No => localizer["No"];
        public string AreYouSure => localizer["AreYouSure"];
        public string Cancel => localizer["Cancel"];
        public string PostalCode => localizer["PostalCode"];
        public string Bosnian => localizer["Bosnian"];
        public string EnglishUS => localizer["EnglishUS"];


        #region SuccMessage
        public string SuccUpdate => localizer["SuccUpdate"];
        public string SuccAdd => localizer["SuccAdd"];
        public string SuccDelete => localizer["SuccDelete"];
        public string SuccChangeStatus => localizer["SuccChangeStatus"];
        #endregion

        #region ErrorMessage
        public string ErrDelete => localizer["ErrDelete"];
        public string ErrChangeStatus => localizer["ErrChangeStatus"];
        #endregion

        #region Country
        public string Country => localizer["Country"];
        public string AddCountry => localizer["AddCountry"];
        public string CountrySettings => localizer["CountrySettings"];
        public string EditCountry => localizer["EditCountry"];
        public string ChooseCountry => localizer["ChooseCountry"];
        #endregion

        #region City
        public string City => localizer["City"];
        public string Cities => localizer["Cities"];
        public string CitySettings => localizer["CitySettings"];
        public string AddCity => localizer["AddCity"];
        public string EditCity => localizer["EditCity"];
        #endregion
    }
}
