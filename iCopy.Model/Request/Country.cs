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
        [Required(ErrorMessage = "ErrNoPhoneNumberCode")]
        public string PhoneNumberCode { get; set; }
        [Required(ErrorMessage = "ErrNoPhoneNumberRegex")]
        public string PhoneNumberRegex { get; set; }
        public bool Active { get; set; }
    }
}
