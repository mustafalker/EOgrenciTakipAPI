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
    public class MufredatKonularsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MufredatKonularsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MufredatKonulars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MufredatKonular>>> GetMufredatKonular()
        {
          if (_context.MufredatKonular == null)
          {
              return NotFound();
          }
            return await _context.MufredatKonular.ToListAsync();
        }

        // GET: api/MufredatKonulars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MufredatKonular>> GetMufredatKonular(string id)
        {
          if (_context.MufredatKonular == null)
          {
              return NotFound();
          }
            var mufredatKonular = await _context.MufredatKonular.FindAsync(id);

            if (mufredatKonular == null)
            {
                return NotFound();
            }

            return mufredatKonular;
        }

        // PUT: api/MufredatKonulars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMufredatKonular(string id, MufredatKonular mufredatKonular)
        {
            if (id != mufredatKonular.MufredatKonuId)
            {
                return BadRequest();
            }

            _context.Entry(mufredatKonular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MufredatKonularExists(id))
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

        // POST: api/MufredatKonulars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MufredatKonular>> PostMufredatKonular(MufredatKonular mufredatKonular)
        {
          if (_context.MufredatKonular == null)
          {
              return Problem("Entity set 'ApplicationDbContext.MufredatKonular'  is null.");
          }
            _context.MufredatKonular.Add(mufredatKonular);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MufredatKonularExists(mufredatKonular.MufredatKonuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMufredatKonular", new { id = mufredatKonular.MufredatKonuId }, mufredatKonular);
        }

        // DELETE: api/MufredatKonulars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMufredatKonular(string id)
        {
            if (_context.MufredatKonular == null)
            {
                return NotFound();
            }
            var mufredatKonular = await _context.MufredatKonular.FindAsync(id);
            if (mufredatKonular == null)
            {
                return NotFound();
            }

            _context.MufredatKonular.Remove(mufredatKonular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MufredatKonularExists(string id)
        {
            return (_context.MufredatKonular?.Any(e => e.MufredatKonuId == id)).GetValueOrDefault();
        }
    }
}
