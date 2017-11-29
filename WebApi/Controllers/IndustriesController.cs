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
    [Route("api/Industries")]
    public class IndustriesController : Controller
    {
        private readonly Dataset _context;

        public IndustriesController(Dataset context)
        {
            _context = context;
        }

        // GET: api/Industries
        [HttpGet]
        public IEnumerable<Industry> GetIndustry()
        {
            return _context.Industry;
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIndustry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.Industry.SingleOrDefaultAsync(m => m.Id == id);

            if (industry == null)
            {
                return NotFound();
            }

            return Ok(industry);
        }

        // PUT: api/Industries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustry([FromRoute] string id, [FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != industry.Id)
            {
                return BadRequest();
            }

            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/Industries
        [HttpPost]
        public async Task<IActionResult> PostIndustry([FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Industry.Add(industry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndustryExists(industry.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIndustry", new { id = industry.Id }, industry);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndustry([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _context.Industry.SingleOrDefaultAsync(m => m.Id == id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.Industry.Remove(industry);
            await _context.SaveChangesAsync();

            return Ok(industry);
        }

        private bool IndustryExists(string id)
        {
            return _context.Industry.Any(e => e.Id == id);
        }
    }
}