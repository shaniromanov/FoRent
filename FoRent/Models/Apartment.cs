using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;





namespace FoRent.Models
{
    public class Apartment
    {
        
        [Display(Name = "מספר סידורי")]
        public int Id { get; set; }

        [Display(Name = "כתובת")]
        public string Name { get; set; }

        [Display(Name = "מחיר למבוגר ללילה")]
        public decimal PriceAdult { get; set; }

        [Display(Name = "מחיר לילד ללילה")]
        public decimal PriceChild { get; set; }

        public Location Location { get; set; }

        public Renter Renter { get; set; }

        public Policy Policy { get; set; }

        public ApartmentAmenities Amenities { get; set; }




    }
}
