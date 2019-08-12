using System;
using System.ComponentModel.DataAnnotations;

namespace iCopy.Model.Request
{
    public class Copier
    {
        [Required(ErrorMessage = "ErrNoName")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ErrNoDescription")]
        [MaxLength(300, ErrorMessage = "ErrMaxLength")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ErrNoStartWorkingTime")]
        [DataType(DataType.Time)]
        public TimeSpan StartWorkingTime { get; set; }

        [Required(ErrorMessage = "ErrNoEndWorkingTime")]
        [DataType(DataType.Time)]
        public TimeSpan EndWorkingTime { get; set; }

        [Required(ErrorMessage = "ErrNoUrl")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        public string Url { get; set; }

        [Required(ErrorMessage = "ErrNoPhoneNumber")]
        [MaxLength(50, ErrorMessage = "ErrMaxLength")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "ErrNoCity")]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "ErrNoCompany")]
        public int CompanyId { get; set; }

        public bool Active { get; set; }
        public Model.Request.ApplicationUserInsert User { get; set; }
        public Model.Request.ProfilePhoto ProfilePhoto { get; set; }
    }
}
