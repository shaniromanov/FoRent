using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoRent.Models
{
    public class OrderPayment
    {
        public int OrderPaymentId { get; set; }

        [Display(Name = "מספר כרטיס אשראי")]
        public int CC_Number { get; set; }

        [Display(Name = "תוקף כרטיס אשראי")]
        public int CC_Exp { get; set; }

        [Display(Name = "3 ספרות בגב הכרטיס")]
        public DateTime CC_CVV { get; set; }

    }
}
