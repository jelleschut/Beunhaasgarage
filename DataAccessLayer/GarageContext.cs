using Core.Models;
using DataAccessLayer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<MaintenanceSpecification> MaintenanceSpecifications { get; set; }
        public DbSet<Model> Models { get; set; }

        public GarageContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GarageDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Brand>(new BrandConfiguration());
            modelBuilder.ApplyConfiguration<Car>(new CarConfiguration());
            modelBuilder.ApplyConfiguration<Owner>(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration<MaintenanceSpecification>(new MaintenanceSpecificationConfiguration());
            modelBuilder.ApplyConfiguration<Model>(new ModelConfiguration());
        }

    }
}
