using Microsoft.AspNetCore.Identity;
using System;

namespace iCopy.Database
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationRole ApplicationRole { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
