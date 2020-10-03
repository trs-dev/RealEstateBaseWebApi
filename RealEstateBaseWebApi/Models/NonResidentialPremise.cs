using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi.Models
{
    public class NonResidentialPremise
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; } //garage, office, shop, ...

        [Range(0, 20)]
        public int Rooms { get; set; }

        [Range(-20, 500)]
        public int Floor { get; set; }

        [Range(0, 1000)]
        public float TotalSquare { get; set; }

        [StringLength(20)]
        public string MaterialOfWall { get; set; }

        [Range(1900, 2050)]
        public int YearOfConstruction { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [Range(0, 100000000)]
        public int Price { get; set; }
    }
}
