using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace iCopy.SERVICES.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }
    }
}
