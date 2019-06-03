using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoRent.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int stars { get; set; }

        public string review { get; set; }
        public Apartment Apartment { get; set; }
    }
}
