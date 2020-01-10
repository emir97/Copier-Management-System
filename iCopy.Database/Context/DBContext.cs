using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iCopy.Database.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Copier> Copiers { get; set; }
        public virtual DbSet<ProfilePhoto> ProfilePhotos { get; set; }
        public virtual DbSet<ApplicationUserProfilePhoto> ApplicationUserProfilePhotos { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<PrintRequest> Requests { get; set; }
        public virtual DbSet<PrintRequestFile> PrintRequestFiles { get; set; }
        public virtual DbSet<ApplicationUserPrintRequestFile> ApplicationUserPrintRequestFile { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
        .Where(e => typeof(BaseEntity<int>).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("CreatedDate")
                    .HasDefaultValueSql("getutcdate()")
                    .ValueGeneratedOnAdd();
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("Active")
                    .HasDefaultValueSql("1")
                    .ValueGeneratedOnAdd();
                modelBuilder.Entity(entityType.ClrType).Property("ModifiedDate").HasDefaultValueSql("getdate()").ValueGeneratedOnUpdate();
            }
            var cascadefks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys())
                .Where(x => x.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var item in cascadefks)
                item.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder
                .Entity<Person>()
                .Property(x => x.Gender)
                .HasConversion(x => x.ToString(), x => (Gender) Enum.Parse(typeof(Gender), x));
        }

    }
}
