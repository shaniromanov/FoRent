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

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }             

        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }               

        [Required]
        [Display(Name = "מספר טלפון")]
        public int Phone { get; set; }

        [Required]
        [Display(Name = "כתובת מייל")]
        public string Mail { get; set; }

        [Display(Name = "הערות מיוחדות לגבי הדירה")]
        public string Comment { get; set; }

        [Required]
        public ICollection<Apartment> Apartments { get; set; }

      




    }
}
