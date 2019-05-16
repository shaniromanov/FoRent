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
        public string Checkin { get; set; } 

        [Display(Name = "צק'אאוט")]
        public string Checkout { get; set; } 

        [Display(Name = "ביטולים")]
        public string Cancellations { get; set; } 

        [Display(Name = "מיטות נוספות")]
        public string Extrabeds { get; set; }

        [Display(Name = "כרטיסי אשראי מתקבלים")]
        public string Creditcardsaccepted { get; set; }

        public ICollection<Apartment> Apartments { get; set; }





    }
}
