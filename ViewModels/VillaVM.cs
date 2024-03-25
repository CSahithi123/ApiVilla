using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VillaVM
    {

        public int Id { get; set; }

        public  string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public int Sqft { get; set; }

        public int Occupancy { get; set; }

        public string ImageUrl { get; set; }

    }
}
