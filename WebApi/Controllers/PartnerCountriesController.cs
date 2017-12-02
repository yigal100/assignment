using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/partner_countries")]
    public class PartnerCountriesController : Controller
    {
        private readonly DatasetContext context;

        public PartnerCountriesController(DatasetContext context)
        {
            this.context = context;
        }

        // GET: api/PartnerCountries
        [HttpGet]
        public IEnumerable<PartnerCountry> GetPartnerCountry()
        {
            return context.PartnerCountry;
        }

        // GET: api/PartnerCountries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartnerCountry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partnerCountry = await context.PartnerCountry.SingleOrDefaultAsync(m => m.Id == id);

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

            context.Entry(partnerCountry).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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

            context.PartnerCountry.Add(partnerCountry);
            try
            {
                await context.SaveChangesAsync();
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

            var partnerCountry = await context.PartnerCountry.SingleOrDefaultAsync(m => m.Id == id);
            if (partnerCountry == null)
            {
                return NotFound();
            }

            context.PartnerCountry.Remove(partnerCountry);
            await context.SaveChangesAsync();

            return Ok(partnerCountry);
        }

        private bool PartnerCountryExists(string id)
        {
            return context.PartnerCountry.Any(e => e.Id == id);
        }
    }
}