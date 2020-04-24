using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICE_API.models;
using Microsoft.AspNetCore.Authorization;

namespace ICE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChalangesController : ControllerBase
    {
        private readonly DataContext _context;

        public ChalangesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Chalanges
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chalange>>> GetChalanges()
        {
            return await _context.chalanges.ToListAsync();
        }

        // GET: api/Chalanges/active
        [HttpGet("active")]
        public async Task<ActionResult<Chalange>> GetActiveChalange()
        {
            return await _context.chalanges.Where(c => c.Active).FirstOrDefaultAsync();
        }

        // GET: api/Chalanges/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Chalange>> GetChalange(int id)
        {
            var chalange = await _context.chalanges.FindAsync(id);

            if (chalange == null)
            {
                return NotFound();
            }

            return chalange;
        }

        // PUT: api/Chalanges/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChalange(int id, Chalange chalange)
        {
            if (id != chalange.ChalangeID)
            {
                return BadRequest();
            }
            var acttiveChalange = await _context.chalanges.Where(c => c.Active).FirstOrDefaultAsync();
            _context.Entry(chalange).State = EntityState.Modified;

            if (chalange.Active == true)
            {
                
                if (chalange.ChalangeID != acttiveChalange.ChalangeID)
                {
                    acttiveChalange.Active = false;
                }
            } else
            {
                if (chalange.ChalangeID == acttiveChalange.ChalangeID)
                {
                    return NotFound();
                }
            }

           


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChalangeExists(id))
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

        // POST: api/Chalanges
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Chalange>> PostChalange(Chalange chalange)
        {
            _context.chalanges.Add(chalange);
            
            if (chalange.Active == true)
            {
                var acttiveChalange = new Chalange();
                acttiveChalange = await _context.chalanges.Where(c => c.Active).FirstOrDefaultAsync();
                acttiveChalange.Active = false;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChalange", new { id = chalange.ChalangeID }, chalange);
        }

        // DELETE: api/Chalanges/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chalange>> DeleteChalange(int id)
        {
            var chalange = await _context.chalanges.FindAsync(id);
            if (chalange.Active)
            {
                return NotFound();
            }

            if (chalange == null)
            {
                return NotFound();
            }

            _context.chalanges.Remove(chalange);
            await _context.SaveChangesAsync();

            return chalange;
        }

        private bool ChalangeExists(int id)
        {
            return _context.chalanges.Any(e => e.ChalangeID == id);
        }
    }
}
