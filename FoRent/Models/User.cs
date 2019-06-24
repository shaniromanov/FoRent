using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class User
    {
        [Display(Name = "סיסמא")]
        [Key]
        public string Password { get; set; }

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }

        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }

        [Display(Name = "מספר טלפון")] 
        public int Phone { get; set; }

        [Display(Name = "כתובת מייל")]
        public string Mail { get; set; }

        [Display(Name = " שם משתמש ")]
        public string Username { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
