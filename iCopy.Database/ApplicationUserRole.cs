using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace iCopy.Database
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        [ForeignKey(nameof(ApplicationRole))]
        public ApplicationRole ApplicationRole { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
