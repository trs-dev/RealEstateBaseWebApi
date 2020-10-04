using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi.Models
{
    public class Requests
    {
        public class ApartmentRequest
        {
            public Apartment Apartment { get; set; }
            public string token { get; set; }
        }
        public class LandPlotRequest
        {
            public LandPlot LandPlot { get; set; }
            public string token { get; set; }
        }
        public class NonResidentialPremiseRequest
        {
            public NonResidentialPremise NonResidentialPremise { get; set; }
            public string token { get; set; }
        }

    }
}
