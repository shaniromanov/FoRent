using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class Renter
    {


        [Required]
        [Display(Name = "סיסמה")]
        public int Id { get; set; }                        

        [Display(Name = "שם ")]
        public string Name { get; set; }                           

        [Required]
        [Display(Name = "מספר טלפון")]
        public int Phone { get; set; }

        [Required]
        [Display(Name = "כתובת מייל")]
        public string Mail { get; set; }


        [Required]
        public ICollection<Apartment> Apartments { get; set; }

      




    }
}
