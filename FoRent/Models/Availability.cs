using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class Availability
    {
        public int Id { get; set; }

        public DateTime NotAvailable { get; set; }
        public Apartment Apartment { get; set; }
    }
}
