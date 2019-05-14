using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class Renter
    {
        [Display(Name = "תעודת זהות")]
        public int Id { get; set; }                        

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }             

        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }               

        [Display(Name = "מספר טלפון")]
        public int Phone { get; set; }                     

        [Display(Name = "כתובת מייל")]
        public string Mail { get; set; }                    

        [Display(Name = "הערות מיוחדות לגבי הדירה")]
        public string Comment { get; set; }                 
    }
}
