using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EOgrenciTakipAPI.Model;

namespace EOgrenciTakipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Alans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alan>>> GetAlanlar()
        {
          if (_context.Alanlar == null)
          {
              return NotFound();
          }
            return await _context.Alanlar.ToListAsync();
        }

        // GET: api/Alans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alan>> GetAlan(string id)
        {
          if (_context.Alanlar == null)
          {
              return NotFound();
          }
            var alan = await _context.Alanlar.FindAsync(id);

            if (alan == null)
            {
                return NotFound();
            }

            return alan;
        }

        // PUT: api/Alans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlan(string id, Alan alan)
        {
            if (id != alan.AlanID)
            {
                return BadRequest();
            }

            _context.Entry(alan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlanExists(id))
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

        // POST: api/Alans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alan>> PostAlan(Alan alan)
        {
          if (_context.Alanlar == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Alanlar'  is null.");
          }
            _context.Alanlar.Add(alan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlanExists(alan.AlanID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlan", new { id = alan.AlanID }, alan);
        }

        // DELETE: api/Alans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlan(string id)
        {
            if (_context.Alanlar == null)
            {
                return NotFound();
            }
            var alan = await _context.Alanlar.FindAsync(id);
            if (alan == null)
            {
                return NotFound();
            }

            _context.Alanlar.Remove(alan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlanExists(string id)
        {
            return (_context.Alanlar?.Any(e => e.AlanID == id)).GetValueOrDefault();
        }
    }
}
