using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoRent.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string Checkin { get; set; } //צק'אין
            public string Checkout { get; set; } //צק'אאוט
            public string Cancellations { get; set; } //ביטולים
            public string Extrabeds { get; set; } //מיטות נוספות
            public string Creditcardsaccepted { get; set; } //כרטיסי אשראי מתקבלים

    }
}
