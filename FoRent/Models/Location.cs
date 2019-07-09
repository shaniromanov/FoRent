using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class Location
    {

        public int Id { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Adress { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
