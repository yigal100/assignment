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
    [Route("api/economic_variables")]
    public class EconomicVariablesController : Controller
    {
        private readonly DatasetContext context;

        public EconomicVariablesController(DatasetContext context)
        {
            this.context = context;
        }

        // GET: api/EconomicVariables
        [HttpGet]
        public IEnumerable<EconomicVariable> GetEconomicVariable()
        {
            return context.EconomicVariables;
        }

        // GET: api/EconomicVariables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEconomicVariable([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicVariable = await context.EconomicVariables.SingleOrDefaultAsync(m => m.Id == id);

            if (economicVariable == null)
            {
                return NotFound();
            }

            return Ok(economicVariable);
        }

        // PUT: api/EconomicVariables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEconomicVariable([FromRoute] string id, [FromBody] EconomicVariable economicVariable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != economicVariable.Id)
            {
                return BadRequest();
            }

            context.Entry(economicVariable).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EconomicVariableExists(id))
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

        // POST: api/EconomicVariables
        [HttpPost]
        public async Task<IActionResult> PostEconomicVariable([FromBody] EconomicVariable economicVariable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.EconomicVariables.Add(economicVariable);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EconomicVariableExists(economicVariable.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEconomicVariable", new { id = economicVariable.Id }, economicVariable);
        }

        // DELETE: api/EconomicVariables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEconomicVariable([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicVariable = await context.EconomicVariables.SingleOrDefaultAsync(m => m.Id == id);
            if (economicVariable == null)
            {
                return NotFound();
            }

            context.EconomicVariables.Remove(economicVariable);
            await context.SaveChangesAsync();

            return Ok(economicVariable);
        }

        private bool EconomicVariableExists(string id)
        {
            return context.EconomicVariables.Any(e => e.Id == id);
        }
    }
}