using System.ComponentModel.DataAnnotations;

namespace iCopy.Model.Request
{
    public class Country
    {
        [Required(ErrorMessage = "ErrNoName")]
        [MinLength(5, ErrorMessage = "ErrMinMaxName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ErrNoShortName")]
        [MinLength(2, ErrorMessage = "ErrMinMaxShortName")]
        public string ShortName { get; set; }
        [Required(ErrorMessage ="ErrNoPhoneCountryCode")]
        public string PhoneNumberCode { get; set; }
    }
}
