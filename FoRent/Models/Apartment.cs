using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace FoRent.Models
{
    public class Apartment
    {
        
        public int Id { get; set; }

        [Display(Name = "מחיר למבוגר ללילה")]
        [Required(ErrorMessage = "שדה חובה")]
        public decimal PriceAdult { get; set; }
        [Required(ErrorMessage ="שדה חובה")]
        [Display(Name = "מחיר לילד ללילה")]
        public decimal PriceChild { get; set; }
       
        public Location Location { get; set; }
       
        public Renter Renter { get; set; }
       
        public Policy Policy { get; set; }
     
        public ApartmentAmenities Amenities { get; set; }
        
        public Image Image { get; set; }

        

      

        public ICollection<ApartmentAvailability> ApartmentAvailabilities { get; set; }
        public ICollection<Order> Orders { get; set; }

        public static implicit operator DbSet<object>(Apartment v)
        {
            throw new NotImplementedException();
        }
    }
}
