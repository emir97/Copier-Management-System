﻿using System;
using Microsoft.AspNetCore.Identity;

namespace iCopy.Database
{
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
