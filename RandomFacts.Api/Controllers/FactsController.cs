using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomFacts.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomFacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactsController : ControllerBase
    {
        private readonly FactContext _context;

        public FactsController(FactContext context)
        {
            _context = context;
        }

        // GET: api/Facts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fact>>> GetFactItems()
        {
            return await _context.FactItems.ToListAsync();
        }

        // GET: api/Facts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fact>> GetFact(int id)
        {
            var fact = await _context.FactItems.FindAsync(id);

            if (fact == null)
            {
                return NotFound();
            }

            return fact;
        }

        // PUT: api/Facts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFact(int id, Fact fact)
        {
            if (id != fact.Id)
            {
                return BadRequest();
            }

            _context.Entry(fact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactExists(id))
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

        // POST: api/Facts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fact>> PostFact(Fact fact)
        {
            _context.FactItems.Add(fact);
            await _context.SaveChangesAsync();

            string urlLink = "https://en.wikipedia.org/wiki/" + fact.Title;

            return CreatedAtAction("GetFact", new { id = fact.Id, title = fact.Title, content = fact.Content, url = urlLink }, fact);
        }

        // DELETE: api/Facts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFact(int id)
        {
            var fact = await _context.FactItems.FindAsync(id);
            if (fact == null)
            {
                return NotFound();
            }

            _context.FactItems.Remove(fact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactExists(int id)
        {
            return _context.FactItems.Any(e => e.Id == id);
        }
    }
}
