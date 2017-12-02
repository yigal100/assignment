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
    [Route("api/declaring_countries")]
    public class DeclaringCountriesController : Controller
    {
        private readonly DatasetContext context;

        public DeclaringCountriesController(DatasetContext context)
        {
            this.context = context;
        }

        // GET: api/DeclaringCountries
        [HttpGet]
        public IEnumerable<DeclaringCountry> GetDeclaringCountry()
        {
            return context.DeclaringCountry;
        }

        // GET: api/DeclaringCountries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeclaringCountry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var declaringCountry = await context.DeclaringCountry.SingleOrDefaultAsync(m => m.Id == id);

            if (declaringCountry == null)
            {
                return NotFound();
            }

            return Ok(declaringCountry);
        }

        // PUT: api/DeclaringCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeclaringCountry([FromRoute] string id, [FromBody] DeclaringCountry declaringCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != declaringCountry.Id)
            {
                return BadRequest();
            }

            context.Entry(declaringCountry).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeclaringCountryExists(id))
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

        // POST: api/DeclaringCountries
        [HttpPost]
        public async Task<IActionResult> PostDeclaringCountry([FromBody] DeclaringCountry declaringCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.DeclaringCountry.Add(declaringCountry);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeclaringCountryExists(declaringCountry.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeclaringCountry", new { id = declaringCountry.Id }, declaringCountry);
        }

        // DELETE: api/DeclaringCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeclaringCountry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var declaringCountry = await context.DeclaringCountry.SingleOrDefaultAsync(m => m.Id == id);
            if (declaringCountry == null)
            {
                return NotFound();
            }

            context.DeclaringCountry.Remove(declaringCountry);
            await context.SaveChangesAsync();

            return Ok(declaringCountry);
        }

        private bool DeclaringCountryExists(string id)
        {
            return context.DeclaringCountry.Any(e => e.Id == id);
        }
    }
}