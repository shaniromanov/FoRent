using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoRent.Models
{
    public class ApartmentAvailability
    {

      
        public int ApartmentId { get; set; }
    
        public Apartment Apartment { get; set; }

  
        public int AvailabilityId { get; set; }
        public Availability Availability { get; set; }
    }
}
   

