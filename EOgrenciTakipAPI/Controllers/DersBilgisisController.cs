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
    public class DersBilgisisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DersBilgisisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DersBilgisis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DersBilgisi>>> GetDersBilgileri()
        {
          if (_context.DersBilgileri == null)
          {
              return NotFound();
          }
            return await _context.DersBilgileri.ToListAsync();
        }

        // GET: api/DersBilgisis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DersBilgisi>> GetDersBilgisi(string id)
        {
          if (_context.DersBilgileri == null)
          {
              return NotFound();
          }
            var dersBilgisi = await _context.DersBilgileri.FindAsync(id);

            if (dersBilgisi == null)
            {
                return NotFound();
            }

            return dersBilgisi;
        }

        // PUT: api/DersBilgisis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDersBilgisi(string id, DersBilgisi dersBilgisi)
        {
            if (id != dersBilgisi.DersProgramiID)
            {
                return BadRequest();
            }

            _context.Entry(dersBilgisi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DersBilgisiExists(id))
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

        // POST: api/DersBilgisis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DersBilgisi>> PostDersBilgisi(DersBilgisi dersBilgisi)
        {
          if (_context.DersBilgileri == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DersBilgileri'  is null.");
          }
            _context.DersBilgileri.Add(dersBilgisi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DersBilgisiExists(dersBilgisi.DersProgramiID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDersBilgisi", new { id = dersBilgisi.DersProgramiID }, dersBilgisi);
        }

        // DELETE: api/DersBilgisis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDersBilgisi(string id)
        {
            if (_context.DersBilgileri == null)
            {
                return NotFound();
            }
            var dersBilgisi = await _context.DersBilgileri.FindAsync(id);
            if (dersBilgisi == null)
            {
                return NotFound();
            }

            _context.DersBilgileri.Remove(dersBilgisi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DersBilgisiExists(string id)
        {
            return (_context.DersBilgileri?.Any(e => e.DersProgramiID == id)).GetValueOrDefault();
        }
    }
}
