using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "כתובת")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "עיר")]
        public string City { get; set; }
        public double? x { get; set; }
        public double? y { get; set; }
        public Apartment Apartment { get; set; }
    }
}
