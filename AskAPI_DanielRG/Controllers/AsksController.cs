using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AskAPI_DanielRG.Models;
using AskAPI_DanielRG.ModelsDTO;

namespace AskAPI_DanielRG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsksController : ControllerBase
    {
        private readonly AnswersDBContext _context;

        public AsksController(AnswersDBContext context)
        {
            _context = context;
        }

        // GET: api/Asks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ask>>> GetAsks()
        {

          if (_context.Asks == null)
          {
              return NotFound();
          }
          var asklist = await _context.Asks.Where(c => c.AskStatusId == 1).ToListAsync();
          if (asklist == null) 
            { return NotFound(); }
           
            return asklist;
        }


        // GET: api/Asks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ask>> GetAsk(long id)
        {
          if (_context.Asks == null)
          {
              return NotFound();
          }
            var ask = await _context.Asks.FindAsync(id);

            if (ask == null)
            {
                return NotFound();
            }

            return ask;
        }

        // PUT: api/Asks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsk(long id, Ask ask)
        {
            if (id != ask.AskId)
            {
                return BadRequest();
            }

            _context.Entry(ask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AskExists(id))
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

        

        // POST: api/Asks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ask>> PostAsk(Ask ask)
        {
          if (_context.Asks == null)
          {
              return Problem("Entity set 'AnswersDBContext.Asks'  is null.");
          }
            _context.Asks.Add(ask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsk", new { id = ask.AskId }, ask);
        }

        // DELETE: api/Asks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsk(long id)
        {
            if (_context.Asks == null)
            {
                return NotFound();
            }
            var ask = await _context.Asks.FindAsync(id);
            if (ask == null)
            {
                return NotFound();
            }

            _context.Asks.Remove(ask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AskExists(long id)
        {
            return (_context.Asks?.Any(e => e.AskId == id)).GetValueOrDefault();
        }
    }
}
