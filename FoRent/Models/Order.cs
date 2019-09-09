using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class Order
    {
        [Display(Name = "מספר הזמנה")]
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

        public User User { get; set; }

        public Renter Renter { get; set; }

        public Order Orders { get; set; }

        public int PaymentId { get; set; }
        public OrderPayment OrderPayment { get; set; }
    }
}
