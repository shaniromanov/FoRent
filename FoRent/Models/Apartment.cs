using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class Apartment
    {
        
        [Display(Name = "קוד דירה")]
        public int Id { get; set; }

        [Display(Name = "כתובת")]
        public string Name { get; set; }

        [Display(Name = "מחיר למבוגר ללילה")]
        public decimal PriceAdult { get; set; }

        [Display(Name = "מחיר לילד ללילה")]
        public decimal PriceChild { get; set; }
        
    }
}
