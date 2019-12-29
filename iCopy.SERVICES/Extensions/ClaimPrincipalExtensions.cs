﻿using System.Security.Claims;

namespace iCopy.SERVICES.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static string GivenName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.GivenName);
        }
    }
}