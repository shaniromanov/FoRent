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
        public string CC_Number { get; set; }

        [Display(Name = "תוקף כרטיס אשראי")]
        public string CC_Exp { get; set; }

        [Display(Name = "3 ספרות בגב הכרטיס")]
        public string CC_CVV { get; set; }

    }
}
