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
    public class DersProgramisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DersProgramisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DersProgramis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DersProgrami>>> GetDersProgramlari()
        {
          if (_context.DersProgramlari == null)
          {
              return NotFound();
          }
            return await _context.DersProgramlari.ToListAsync();
        }

        // GET: api/DersProgramis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DersProgrami>> GetDersProgrami(string id)
        {
          if (_context.DersProgramlari == null)
          {
              return NotFound();
          }
            var dersProgrami = await _context.DersProgramlari.FindAsync(id);

            if (dersProgrami == null)
            {
                return NotFound();
            }

            return dersProgrami;
        }

        // PUT: api/DersProgramis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDersProgrami(string id, DersProgrami dersProgrami)
        {
            if (id != dersProgrami.DersProgramiID)
            {
                return BadRequest();
            }

            _context.Entry(dersProgrami).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DersProgramiExists(id))
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

        // POST: api/DersProgramis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DersProgrami>> PostDersProgrami(DersProgrami dersProgrami)
        {
          if (_context.DersProgramlari == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DersProgramlari'  is null.");
          }
            _context.DersProgramlari.Add(dersProgrami);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DersProgramiExists(dersProgrami.DersProgramiID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDersProgrami", new { id = dersProgrami.DersProgramiID }, dersProgrami);
        }

        // DELETE: api/DersProgramis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDersProgrami(string id)
        {
            if (_context.DersProgramlari == null)
            {
                return NotFound();
            }
            var dersProgrami = await _context.DersProgramlari.FindAsync(id);
            if (dersProgrami == null)
            {
                return NotFound();
            }

            _context.DersProgramlari.Remove(dersProgrami);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DersProgramiExists(string id)
        {
            return (_context.DersProgramlari?.Any(e => e.DersProgramiID == id)).GetValueOrDefault();
        }
    }
}
