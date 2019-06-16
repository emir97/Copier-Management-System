using System;
using Microsoft.AspNetCore.Identity;

namespace iCopy.Database
{
    public class ApplicationRole : IdentityRole<int>
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
