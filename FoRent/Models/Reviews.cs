using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int stars { get; set; }

        [Display(Name = "מיקום")]
        public int Location { get; set; }

        [Display(Name = "רמת נקיון")]
        public int Cleanliness { get; set; }

        [Display(Name = "צ'ק אין")]
        public int Checkin { get; set; }

        [Display(Name = "תמורה למחיר")]
        public int Price { get; set; }

        public int Mm { get; set; }

        public int review { get; set; }
        public Apartment Apartment { get; set; }
    }
}
