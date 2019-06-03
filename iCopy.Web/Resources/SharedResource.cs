using Microsoft.Extensions.Localization;
using System.Reflection;

namespace iCopy.Web.Resources
{
    public class SharedResource
    {
        private readonly IStringLocalizer localizer;

        public SharedResource(IStringLocalizerFactory localizer)
        {
            this.localizer = localizer.Create(nameof(SharedResource), new AssemblyName(typeof(SharedResource).Assembly.FullName).Name);
        }

        public string SaveChanges => localizer[nameof(SaveChanges)];
        public string Close => localizer[nameof(Close)];
        public string Name => localizer[nameof(Name)];
        public string ShortName => localizer[nameof(ShortName)];
        public string PhoneCode => localizer[nameof(PhoneCode)];
        public string Active => localizer[nameof(Active)];
        public string Actions => localizer[nameof(Actions)];
        public string Search => localizer[nameof(Search)];
        public string Reset => localizer[nameof(Reset)];
        public string Inactive => localizer[nameof(Inactive)];
        public string All => localizer[nameof(All)];
        public string LocationSettings => localizer[nameof(LocationSettings)];
        public string Countries => localizer[nameof(Countries)];
        public string Yes => localizer[nameof(Yes)];
        public string No => localizer[nameof(No)];
        public string AreYouSure => localizer[nameof(AreYouSure)];
        public string Cancel => localizer[nameof(Cancel)];
        public string PostalCode => localizer[nameof(PostalCode)];
        public string Bosnian => localizer[nameof(Bosnian)];
        public string EnglishUS => localizer[nameof(EnglishUS)];
        public string Privacy => localizer[nameof(Privacy)];
        public string Contact => localizer[nameof(Contact)];
        public string Team => localizer[nameof(Team)];
        public string About => localizer[nameof(About)];
        public string Legal => localizer[nameof(Legal)];
        public string WelcomeToCopierManagementSystem => localizer[nameof(WelcomeToCopierManagementSystem)];
        public string CopierManagementSystem => localizer[nameof(CopierManagementSystem)];
        public string LanguageImagePath => localizer[nameof(LanguageImagePath)];
        public string OR => localizer[nameof(OR)];

        #region SuccMessage
        public string SuccUpdate => localizer[nameof(SuccUpdate)];
        public string SuccAdd => localizer[nameof(SuccAdd)];
        public string SuccDelete => localizer[nameof(SuccDelete)];
        public string SuccChangeStatus => localizer[nameof(SuccChangeStatus)];
        #endregion

        #region ErrorMessage
        public string ErrDelete => localizer[nameof(ErrDelete)];
        public string ErrChangeStatus => localizer[nameof(ErrChangeStatus)];
        #endregion

        #region Country
        public string Country => localizer[nameof(Country)];
        public string AddCountry => localizer[nameof(AddCountry)];
        public string CountrySettings => localizer[nameof(CountrySettings)];
        public string EditCountry => localizer[nameof(EditCountry)];
        public string ChooseCountry => localizer[nameof(ChooseCountry)];
        #endregion

        #region City
        public string City => localizer[nameof(City)];
        public string Cities => localizer[nameof(Cities)];
        public string CitySettings => localizer[nameof(CitySettings)];
        public string AddCity => localizer[nameof(AddCity)];
        public string EditCity => localizer[nameof(EditCity)];
        #endregion

        #region Login
        public string Login => localizer[nameof(Login)];
        public string ForgotPassword => localizer[nameof(ForgotPassword)];
        public string UsernameOrEmail => localizer[nameof(UsernameOrEmail)];
        public string Password => localizer[nameof(Password)];

        #endregion
    }
}
