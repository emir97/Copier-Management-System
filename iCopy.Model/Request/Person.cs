using iCopy.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace iCopy.Model.Request
{
    public class Person
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoFirstName")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoLastName")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        public string LastName { get; set; }
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        public string MiddleName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoGender")]
        public Gender Gender { get; set; }
        public int CityId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoAddress")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        public string Address { get; set; }
        [DataType(DataType.Date, ErrorMessage = "ErrDateWrongFormat")]
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
