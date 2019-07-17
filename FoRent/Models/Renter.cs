using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class Renter: User
    {
      
        public ICollection<Apartment> Apartments { get; set; }
      
    }
}
