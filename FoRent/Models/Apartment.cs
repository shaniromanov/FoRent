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
        
        public int Id { get; set; }

        [Display(Name = "מחיר למבוגר ללילה")]
        [Required]
        public decimal PriceAdult { get; set; }
        [Required]
        [Display(Name = "מחיר לילד ללילה")]
        public decimal PriceChild { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public Renter Renter { get; set; }
        [Required]
        public Policy Policy { get; set; }
        [Required]
        public ApartmentAmenities Amenities { get; set; }

        public ICollection<Reviews> Reviews { get; set; }

        public ICollection<Availability> Availability { get; set; }


    }
}
