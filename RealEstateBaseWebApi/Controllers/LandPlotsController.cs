using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateBaseWebApi.Models;

namespace RealEstateBaseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandPlotsController : ControllerBase
    {
        private readonly RealtyContext _context;

        public LandPlotsController(RealtyContext context)
        {
            _context = context;
        }

        // GET: api/LandPlots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandPlot>>> GetLandPlots()
        {
            return await _context.LandPlots.ToListAsync();
        }

        // GET: api/LandPlots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LandPlot>> GetLandPlot(int id)
        {
            var landPlot = await _context.LandPlots.FindAsync(id);

            if (landPlot == null)
            {
                return NotFound();
            }

            return landPlot;
        }

        // PUT: api/LandPlots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandPlot(int id, LandPlot landPlot)
        {
            if (id != landPlot.Id)
            {
                return BadRequest();
            }

            _context.Entry(landPlot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandPlotExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LandPlots
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LandPlot>> PostLandPlot(LandPlot landPlot)
        {
            _context.LandPlots.Add(landPlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLandPlot", new { id = landPlot.Id }, landPlot);
        }

        // DELETE: api/LandPlots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LandPlot>> DeleteLandPlot(int id)
        {
            var landPlot = await _context.LandPlots.FindAsync(id);
            if (landPlot == null)
            {
                return NotFound();
            }

            _context.LandPlots.Remove(landPlot);
            await _context.SaveChangesAsync();

            return landPlot;
        }

        private bool LandPlotExists(int id)
        {
            return _context.LandPlots.Any(e => e.Id == id);
        }
    }
}
