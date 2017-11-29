using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/PartnerCountries")]
    public class PartnerCountriesController : Controller
    {
        private readonly Dataset _context;

        public PartnerCountriesController(Dataset context)
        {
            _context = context;
        }

        // GET: api/PartnerCountries
        [HttpGet]
        public IEnumerable<PartnerCountry> GetPartnerCountry()
        {
            return _context.PartnerCountry;
        }

        // GET: api/PartnerCountries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartnerCountry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partnerCountry = await _context.PartnerCountry.SingleOrDefaultAsync(m => m.Id == id);

            if (partnerCountry == null)
            {
                return NotFound();
            }

            return Ok(partnerCountry);
        }

        // PUT: api/PartnerCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartnerCountry([FromRoute] string id, [FromBody] PartnerCountry partnerCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partnerCountry.Id)
            {
                return BadRequest();
            }

            _context.Entry(partnerCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerCountryExists(id))
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

        // POST: api/PartnerCountries
        [HttpPost]
        public async Task<IActionResult> PostPartnerCountry([FromBody] PartnerCountry partnerCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PartnerCountry.Add(partnerCountry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartnerCountryExists(partnerCountry.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartnerCountry", new { id = partnerCountry.Id }, partnerCountry);
        }

        // DELETE: api/PartnerCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnerCountry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partnerCountry = await _context.PartnerCountry.SingleOrDefaultAsync(m => m.Id == id);
            if (partnerCountry == null)
            {
                return NotFound();
            }

            _context.PartnerCountry.Remove(partnerCountry);
            await _context.SaveChangesAsync();

            return Ok(partnerCountry);
        }

        private bool PartnerCountryExists(string id)
        {
            return _context.PartnerCountry.Any(e => e.Id == id);
        }
    }
}