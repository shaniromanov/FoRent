using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yiddisherent.Models;
using FoRent.Models;

namespace FoRent.Models
{
    public class FoRentContext : DbContext
    {
        public FoRentContext (DbContextOptions<FoRentContext> options)
            : base(options)
        {
        }

        public DbSet<yiddisherent.Models.Apartment> Apartment { get; set; }

        public DbSet<yiddisherent.Models.Location> Location { get; set; }

        public DbSet<yiddisherent.Models.Order> Order { get; set; }

        public DbSet<FoRent.Models.Renter> Renter { get; set; }
    }
}
