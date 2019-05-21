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

        public DbSet<FoRent.Models.Apartment> Apartment { get; set; }

        public DbSet<FoRent.Models.Location> Location { get; set; }

        public DbSet<FoRent.Models.Order> Order { get; set; }

        public DbSet<FoRent.Models.Renter> Renter { get; set; }

        public DbSet<FoRent.Models.ApartmentAmenities> ApartmentAmenities { get; set; }


        public DbSet<FoRent.Models.Policy> Policy { get; set; }


        public DbSet<FoRent.Models.Hirer> Hirer { get; set; }
    }
}
