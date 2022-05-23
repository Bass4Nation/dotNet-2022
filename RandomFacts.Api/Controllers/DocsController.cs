using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomFacts.Api.Models;

namespace RandomFacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly DocContext _context;

        public DocsController(DocContext context)
        {
            _context = context;
        }

        // GET: api/Docs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doc>>> GetDocItems()
        {
            return await _context.DocItems.ToListAsync();
        }

        // GET: api/Docs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doc>> GetDoc(int id)
        {
            var doc = await _context.DocItems.FindAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return doc;
        }

        // PUT: api/Docs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoc(int id, Doc doc)
        {
            if (id != doc.Id)
            {
                return BadRequest();
            }

            _context.Entry(doc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocExists(id))
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

        // POST: api/Docs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doc>> PostDoc(Doc doc)
        {
            _context.DocItems.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoc", new { id = doc.Id, title = doc.Title, content = doc.Content}, doc);
        }

        // DELETE: api/Docs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoc(int id)
        {
            var doc = await _context.DocItems.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }

            _context.DocItems.Remove(doc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocExists(int id)
        {
            return _context.DocItems.Any(e => e.Id == id);
        }
    }
}
