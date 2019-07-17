using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "סיסמא")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }


        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }


        [Display(Name = "מספר טלפון")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = "כתובת מייל")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        [Display(Name = " שם משתמש ")]

        public string Username{ get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
