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
    public class NonResidentialPremisesController : ControllerBase
    {
        private readonly RealtyContext _context;

        public NonResidentialPremisesController(RealtyContext context)
        {
            _context = context;
        }

        // GET: api/NonResidentialPremises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonResidentialPremise>>> GetNonResidentialPremises()
        {
            return await _context.NonResidentialPremises.ToListAsync();
        }

        // GET: api/NonResidentialPremises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NonResidentialPremise>> GetNonResidentialPremise(int id)
        {
            var nonResidentialPremise = await _context.NonResidentialPremises.FindAsync(id);

            if (nonResidentialPremise == null)
            {
                return NotFound();
            }

            return nonResidentialPremise;
        }

        // PUT: api/NonResidentialPremises/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNonResidentialPremise(int id, NonResidentialPremise nonResidentialPremise)
        {
            if (id != nonResidentialPremise.Id)
            {
                return BadRequest();
            }

            _context.Entry(nonResidentialPremise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonResidentialPremiseExists(id))
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

        // POST: api/NonResidentialPremises
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NonResidentialPremise>> PostNonResidentialPremise(NonResidentialPremise nonResidentialPremise)
        {
            _context.NonResidentialPremises.Add(nonResidentialPremise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNonResidentialPremise", new { id = nonResidentialPremise.Id }, nonResidentialPremise);
        }

        // DELETE: api/NonResidentialPremises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NonResidentialPremise>> DeleteNonResidentialPremise(int id)
        {
            var nonResidentialPremise = await _context.NonResidentialPremises.FindAsync(id);
            if (nonResidentialPremise == null)
            {
                return NotFound();
            }

            _context.NonResidentialPremises.Remove(nonResidentialPremise);
            await _context.SaveChangesAsync();

            return nonResidentialPremise;
        }

        private bool NonResidentialPremiseExists(int id)
        {
            return _context.NonResidentialPremises.Any(e => e.Id == id);
        }
    }
}
