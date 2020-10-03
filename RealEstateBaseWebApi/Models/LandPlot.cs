using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi.Models
{
    public class LandPlot
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; } //for construction, farming, ...

        [Range(0, 10000)]
        public float TotalSquare { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [Range(0, 100000000)]
        public int Price { get; set; }
    }
}
