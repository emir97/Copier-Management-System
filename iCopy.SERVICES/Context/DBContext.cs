using iCopy.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iCopy.SERVICES.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ProfilePhoto> ProfilePhotos { get; set; }
        public virtual DbSet<CompanyProfilePhoto> CompanyProfilePhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
        .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("CreatedDate")
                    .HasDefaultValueSql("getutcdate()");
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("Active")
                    .HasDefaultValueSql("1");
            }
            var cascadefks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys())
                .Where(x => x.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var item in cascadefks)
                item.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
