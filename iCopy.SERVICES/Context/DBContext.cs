using iCopy.Database;
using Microsoft.EntityFrameworkCore;

namespace iCopy.SERVICES.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Country>()
                .Property(b => b.Active)
                .HasDefaultValueSql("1");
        }
    }
}
