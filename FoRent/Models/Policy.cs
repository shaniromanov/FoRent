using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class Policy
    {
    
        public int Id { get; set; }

        [Display(Name = "צק' אין")]
        [DataType(DataType.Time)]
        public DateTime Checkin { get; set; } 

        [Display(Name = "צק'אאוט")]
        [DataType(DataType.Time)]
        public DateTime Checkout { get; set; } 

        [Display(Name = "ביטולים")]
        public string Cancellations { get; set; } 

        [Display(Name = "מיטות נוספות")]
        public bool Extrabeds { get; set; }


        public Apartment Apartment { get; set; }





    }
}
