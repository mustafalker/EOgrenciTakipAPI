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
    public class KonuBilgisisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KonuBilgisisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KonuBilgisis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KonuBilgisi>>> GetKonuBilgileri()
        {
          if (_context.KonuBilgileri == null)
          {
              return NotFound();
          }
            return await _context.KonuBilgileri.ToListAsync();
        }

        // GET: api/KonuBilgisis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KonuBilgisi>> GetKonuBilgisi(string id)
        {
          if (_context.KonuBilgileri == null)
          {
              return NotFound();
          }
            var konuBilgisi = await _context.KonuBilgileri.FindAsync(id);

            if (konuBilgisi == null)
            {
                return NotFound();
            }

            return konuBilgisi;
        }

        // PUT: api/KonuBilgisis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKonuBilgisi(string id, KonuBilgisi konuBilgisi)
        {
            if (id != konuBilgisi.KonuBilgisiID)
            {
                return BadRequest();
            }

            _context.Entry(konuBilgisi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonuBilgisiExists(id))
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

        // POST: api/KonuBilgisis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KonuBilgisi>> PostKonuBilgisi(KonuBilgisi konuBilgisi)
        {
          if (_context.KonuBilgileri == null)
          {
              return Problem("Entity set 'ApplicationDbContext.KonuBilgileri'  is null.");
          }
            _context.KonuBilgileri.Add(konuBilgisi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KonuBilgisiExists(konuBilgisi.KonuBilgisiID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKonuBilgisi", new { id = konuBilgisi.KonuBilgisiID }, konuBilgisi);
        }

        // DELETE: api/KonuBilgisis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKonuBilgisi(string id)
        {
            if (_context.KonuBilgileri == null)
            {
                return NotFound();
            }
            var konuBilgisi = await _context.KonuBilgileri.FindAsync(id);
            if (konuBilgisi == null)
            {
                return NotFound();
            }

            _context.KonuBilgileri.Remove(konuBilgisi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KonuBilgisiExists(string id)
        {
            return (_context.KonuBilgileri?.Any(e => e.KonuBilgisiID == id)).GetValueOrDefault();
        }
    }
}
