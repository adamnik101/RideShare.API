using Microsoft.EntityFrameworkCore;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.DataAccess
{
    public class RideshareContext : DbContext
    {
        public RideshareContext ()
        {

        }
        public RideshareContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=RideShareV1; Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RideshareContext).Assembly);

            modelBuilder.Entity<CarRestriction>().HasKey(x => new { x.CarId, x.RestrictionId});
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Domain.Entities.Type> Types { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
        public DbSet<CarRestriction> CarRestrictions { get; set; }
        public DbSet<RideRequest> RideRequests { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
    }
}
