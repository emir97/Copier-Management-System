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
        public string Address => localizer[nameof(Address)];
        public string PhoneNumber => localizer[nameof(PhoneNumber)];
        public string Email => localizer[nameof(Email)];
        public string ContactAgent => localizer[nameof(ContactAgent)];
        public string CopierSettings => localizer[nameof(CopierSettings)];
        public string SystemSettings => localizer[nameof(SystemSettings)];
        public string PhoneNumberRegex => localizer[nameof(PhoneNumberRegex)];
        public string AccountSettings => localizer[nameof(AccountSettings)];
        public string Completed => localizer[nameof(Completed)];
        public string Previous => localizer[nameof(Previous)];
        public string Submit => localizer[nameof(Submit)];
        public string NextStep => localizer[nameof(NextStep)];
        public string Username => localizer[nameof(Username)];
        public string ProfileImage => localizer[nameof(ProfileImage)];
        public string DragFilesOrClickToUpload => localizer[nameof(DragFilesOrClickToUpload)];
        public string Confirm => localizer[nameof(Confirm)];
        public string PasswordConfirm => localizer[nameof(PasswordConfirm)];
        public string CorrectErrorBeforeGoToNextStep => localizer[nameof(CorrectErrorBeforeGoToNextStep)];
        public string ContactEmail => localizer[nameof(ContactEmail)];
        public string Details => localizer[nameof(Details)];
        public string CompanyDetails => localizer[nameof(CompanyDetails)];
        public string AccountDetails => localizer[nameof(AccountDetails)];
        public string EmailConfirmed => localizer[nameof(EmailConfirmed)];
        public string EmailNotConfirmed => localizer[nameof(EmailNotConfirmed)];
        public string LockoutEnd => localizer[nameof(LockoutEnd)];
       
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
        public string ChooseCity => localizer[nameof(ChooseCity)];
        #endregion

        #region Company
        public string CompanySettings => localizer[nameof(CompanySettings)];
        public string AddCompany => localizer[nameof(AddCompany)];
        public string JIB => localizer[nameof(JIB)];
        public string ContactAgentPhoneNumber => localizer[nameof(ContactAgentPhoneNumber)];
        #endregion

        #region Login
        public string Login => localizer[nameof(Login)];
        public string ForgotPassword => localizer[nameof(ForgotPassword)];
        public string UsernameOrEmail => localizer[nameof(UsernameOrEmail)];
        public string Password => localizer[nameof(Password)];
        #endregion
    }
}
