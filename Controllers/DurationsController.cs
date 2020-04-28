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
    public class DurationsController : ControllerBase
    {
        private readonly DataContext _context;

        public DurationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Durations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duration>>> GetDurations()
        {
            return await _context.Durations.ToListAsync();
        }

        // GET: api/Durations/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Duration>> GetDuration(int id)
        {
            var duration = await _context.Durations.FindAsync(id);

            if (duration == null)
            {
                return NotFound();
            }

            return duration;
        }

        // PUT: api/Durations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuration(int id, Duration duration)
        {
            if (id != duration.DurationID)
            {
                return BadRequest();
            }

            _context.Entry(duration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DurationExists(id))
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

        // POST: api/Durations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Duration>> PostDuration(Duration duration)
        {
            _context.Durations.Add(duration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuration", new { id = duration.DurationID }, duration);
        }

        // DELETE: api/Durations/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Duration>> DeleteDuration(int id)
        {
            var duration = await _context.Durations.FindAsync(id);
            if (duration == null)
            {
                return NotFound();
            }

            _context.Durations.Remove(duration);
            await _context.SaveChangesAsync();

            return duration;
        }

        private bool DurationExists(int id)
        {
            return _context.Durations.Any(e => e.DurationID == id);
        }
    }
}
