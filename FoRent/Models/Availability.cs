using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoRent.Models
{
    public class Availability
    {
        [Display(Name = "צ'אק אין")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "צ'אק אאוט")]
        public DateTime CheckOut { get; set; }
    }
}
