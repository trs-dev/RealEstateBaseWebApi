using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi.Models
{
    public class LandPlot
    {
        public string Type { get; set; } //for construction, farming, ...

        public float TotalSquare { get; set; }

        public string Address { get; set; }
    }
}
