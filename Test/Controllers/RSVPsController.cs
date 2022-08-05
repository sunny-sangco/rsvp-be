using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public RSVPController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/RSVP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RSVP>>> GetRSVP()
        {
            return await _context.RSVP.ToListAsync();
        }

        // GET: api/RSVP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RSVP>> GetRSVP(int id)
        {
            var rSVP = await _context.RSVP.FindAsync(id);

            if (rSVP == null)
            {
                return NotFound();
            }

            return rSVP;
        }

        // PUT: api/RSVP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRSVP(int id, RSVP rSVP)
        {
            if (id != rSVP.Id)
            {
                return BadRequest();
            }

            _context.Entry(rSVP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RSVPExists(id))
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

        // POST: api/RSVP
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RSVP>> PostRSVP(RSVP rSVP)
        {
            _context.RSVP.Add(rSVP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRSVP", new { id = rSVP.Id }, rSVP);
        }

        // DELETE: api/RSVP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RSVP>> DeleteRSVP(int id)
        {
            var rSVP = await _context.RSVP.FindAsync(id);
            if (rSVP == null)
            {
                return NotFound();
            }

            _context.RSVP.Remove(rSVP);
            await _context.SaveChangesAsync();

            return rSVP;
        }

        private bool RSVPExists(int id)
        {
            return _context.RSVP.Any(e => e.Id == id);
        }
    }
}
