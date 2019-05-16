using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class ApartmentAmenities
    {
        public int Id { get; set; }

        [Display(Name = "מספר חדרים בדירה")]
        public double NumOfRooms { get; set; }

        [Display(Name = "כמות מיטות בדירה")]
        public int NumOfPersons { get; set; }           

        [Display(Name = "תיאור הדירה")]
        public string Description { get; set; }

        [Display(Name = "פלטה")]
        public bool Plata { get; set; }

        [Display(Name = "מיחם")]
        public bool HotWater { get; set; }

        [Display(Name = "חניה")]
        public bool Parking { get; set; }

        [Display(Name = "WIFI")]
        public bool Wifi { get; set; }

        [Display(Name = "נגישות לנכים")]
        public bool Accessibility { get; set; }

        [Display(Name = "מיזוג בדירה")]
        public bool AirConditioning { get; set; }       

        [Display(Name = "מרפסת")]
        public bool Balcony { get; set; }

        [Display(Name = "הערות נוספות")]
        public string Comment { get; set; }

        public ICollection<Apartment> Apartments { get; set; }

    }
}
