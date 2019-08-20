using System;
using Microsoft.AspNetCore.Identity;

namespace iCopy.Database
{
    public class ApplicationUserUserToken : IdentityUserToken<int>
    {
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public TokenType TokenType { get; set; }
    }

    public enum TokenType
    {
        AccountActivation
    }
}
