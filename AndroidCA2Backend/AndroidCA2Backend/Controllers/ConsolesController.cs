#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndroidCA2Backend;
using AndroidCA2Backend.Data;

namespace AndroidCA2Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolesController : ControllerBase
    {
        private readonly AndroidCA2BackendContext _context;

        public ConsolesController(AndroidCA2BackendContext context)
        {
            _context = context;
        }

        // GET: api/Consoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Console>>> GetConsole()
        {
            return await _context.Console.ToListAsync();
        }

        // GET: api/Consoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Console>> GetConsole(int id)
        {
            var console = await _context.Console.FindAsync(id);

            if (console == null)
            {
                return NotFound();
            }

            return console;
        }

        // PUT: api/Consoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsole(int id, Console console)
        {
            if (id != console.Id)
            {
                return BadRequest();
            }

            _context.Entry(console).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleExists(id))
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

        // POST: api/Consoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Console>> PostConsole(Console console)
        {
            _context.Console.Add(console);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsole", new { id = console.Id }, console);
        }

        // DELETE: api/Consoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsole(int id)
        {
            var console = await _context.Console.FindAsync(id);
            if (console == null)
            {
                return NotFound();
            }

            _context.Console.Remove(console);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsoleExists(int id)
        {
            return _context.Console.Any(e => e.Id == id);
        }
    }
}
