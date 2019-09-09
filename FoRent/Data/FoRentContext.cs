using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;

namespace FoRent.Models
{
    public class FoRentContext : DbContext
    {
        public FoRentContext (DbContextOptions<FoRentContext> options)
            : base(options)
        {
        }

       

        public DbSet<FoRent.Models.Location> Location { get; set; }

        public DbSet<FoRent.Models.Order> Order { get; set; }

        public DbSet<FoRent.Models.Renter> Renter { get; set; }

        public DbSet<FoRent.Models.ApartmentAmenities> ApartmentAmenities { get; set; }


        public DbSet<FoRent.Models.Policy> Policy { get; set; }


        public DbSet<FoRent.Models.User> User { get; set; }
        

        public DbSet<FoRent.Models.Image> Image { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentAvailability>()
                .HasKey(t => new { t.AvailabilityId, t.ApartmentId });

            modelBuilder.Entity<ApartmentAvailability>()
               .HasOne(pt => pt.Availability)
               .WithMany(t => t.ApartmentAvailabilities)
               .HasForeignKey(pt => pt.AvailabilityId);

            modelBuilder.Entity<ApartmentAvailability>()
                .HasOne(pt => pt.Apartment)
                .WithMany(p => p.ApartmentAvailabilities)
                .HasForeignKey(pt => pt.ApartmentId);
            
        }
      
        public DbSet<FoRent.Models.Apartment> Apartment { get; set; }
        public DbSet<FoRent.Models.Availability> Availability { get; set; }
        public DbSet<FoRent.Models.ApartmentAvailability> ApartmentAvailability { get; set; }
        public DbSet<FoRent.Models.Reviews> Reviews { get; set; }
        //public DbSet<FoRent.Models.ApartmentAvailability> ApartmentAvailabilities { get; set; }
    }
}
