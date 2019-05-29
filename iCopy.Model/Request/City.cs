using System.ComponentModel.DataAnnotations;

namespace iCopy.Model.Request
{
    public class City
    {
        [Required(ErrorMessage = "ErrNoName")]
        [MinLength(5, ErrorMessage = "ErrMinMaxName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ErrNoShortName")]
        [MinLength(2, ErrorMessage = "ErrMinMaxShortName")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "ErrNoPostalCode")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "ErrNoCountry")]
        public int CountryID { get; set; }
        public bool Active { get; set; }
    }
}
