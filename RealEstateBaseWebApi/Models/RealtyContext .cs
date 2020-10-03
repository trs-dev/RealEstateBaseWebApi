using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateBaseWebApi.Models
{
    public class RealtyContext : DbContext      //one context for all types of realty
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<LandPlot> LandPlots { get; set; }
        public DbSet<NonResidentialPremise> NonResidentialPremises { get; set; }


        public RealtyContext(DbContextOptions<RealtyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
