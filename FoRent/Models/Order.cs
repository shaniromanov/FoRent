using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace yiddisherent.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        [Display(Name = "מספר מבוגרים")]
        public int QuantityAdult { get; set; }

        [Display(Name = "מספר ילדים")]
        public int QuantityChild { get; set; }

        [Display(Name = "צ'אק אין")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "צ'אק אאוט")]
        public DateTime CheckOut { get; set; }

    }
}
