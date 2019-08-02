using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoRent.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string LivingRoom { get; set; }
        public string DiningRoom { get; set; }
        public string BedRoom { get; set; }
        public string Ketchen { get; set; }

        public Apartment Apartment { get; set; }


    }
}
