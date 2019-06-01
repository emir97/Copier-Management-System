using Microsoft.EntityFrameworkCore;

namespace iCopy.SERVICES.Context
{
    public class AuthContext : DBContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }
    }
}
