using System.ComponentModel.DataAnnotations.Schema;

namespace iCopy.Database
{
    public class CompanyProfilePhoto : BaseEntity
    {
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey(nameof(ProfilePhoto))]
        public int ProfilePhotoId { get; set; }
        public ProfilePhoto ProfilePhoto { get; set; }
    }
}
