using System;
using Microsoft.AspNetCore.Identity;
namespace iCopy.Database
{
    public class ApplicationUser : IdentityUser<int>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
