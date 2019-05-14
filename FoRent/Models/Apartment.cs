using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace yiddisherent.Models
{
    public class Apartment
    {
        [Key]
        [Display(Name = "סיסמה")]
        public int Id { get; set; }

        [Display(Name = "שם הדירה")]
        public string Name { get; set; }

        [Display(Name = "מחיר למבוגר ללילה")]
        public decimal PriceAdult { get; set; }

        [Display(Name = "מחיר לילד ללילה")]
        public decimal PriceChild { get; set; }
        חחח
    }
}
