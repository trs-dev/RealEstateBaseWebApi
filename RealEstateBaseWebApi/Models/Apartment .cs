using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        public int Rooms { get; set; }
        public int Floor { get; set; }

        public float TotalSquare { get; set; }
        public float LiveSquare { get; set; }
        public float KitchenSquare { get; set; }

        public string MaterialOfWall { get; set; }
        public int YearOfConstruction { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }
    }
}
