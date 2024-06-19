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
    public class MufredatDerslersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MufredatDerslersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MufredatDerslers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MufredatDersler>>> GetMufredatDersler()
        {
          if (_context.MufredatDersler == null)
          {
              return NotFound();
          }
            return await _context.MufredatDersler.ToListAsync();
        }

        // GET: api/MufredatDerslers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MufredatDersler>> GetMufredatDersler(string id)
        {
          if (_context.MufredatDersler == null)
          {
              return NotFound();
          }
            var mufredatDersler = await _context.MufredatDersler.FindAsync(id);

            if (mufredatDersler == null)
            {
                return NotFound();
            }

            return mufredatDersler;
        }

        // PUT: api/MufredatDerslers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMufredatDersler(string id, MufredatDersler mufredatDersler)
        {
            if (id != mufredatDersler.MufredatDersId)
            {
                return BadRequest();
            }

            _context.Entry(mufredatDersler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MufredatDerslerExists(id))
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

        // POST: api/MufredatDerslers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MufredatDersler>> PostMufredatDersler(MufredatDersler mufredatDersler)
        {
          if (_context.MufredatDersler == null)
          {
              return Problem("Entity set 'ApplicationDbContext.MufredatDersler'  is null.");
          }
            _context.MufredatDersler.Add(mufredatDersler);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MufredatDerslerExists(mufredatDersler.MufredatDersId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMufredatDersler", new { id = mufredatDersler.MufredatDersId }, mufredatDersler);
        }

        // DELETE: api/MufredatDerslers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMufredatDersler(string id)
        {
            if (_context.MufredatDersler == null)
            {
                return NotFound();
            }
            var mufredatDersler = await _context.MufredatDersler.FindAsync(id);
            if (mufredatDersler == null)
            {
                return NotFound();
            }

            _context.MufredatDersler.Remove(mufredatDersler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MufredatDerslerExists(string id)
        {
            return (_context.MufredatDersler?.Any(e => e.MufredatDersId == id)).GetValueOrDefault();
        }
    }
}
