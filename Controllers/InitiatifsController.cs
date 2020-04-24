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
    public class InitiatifsController : ControllerBase
    {
        private readonly DataContext _context;

        public InitiatifsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Initiatifs
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Initiatif>>> GetInitiatifs()
        {
            return await _context.Initiatifs.ToListAsync();
        }



        // GET: api/Initiatifs/whereShowIsTrue
        [HttpGet("whereShowIsTrue")]
        public async Task<ActionResult<IEnumerable<Initiatif>>> getProjectsWhereShowIsTrue()
        {
            return await _context.Initiatifs.Where(i => i.Confirmed == true).ToListAsync();
        }

        // GET: api/Initiatifs/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Initiatif>> GetInitiatif(int id)
        {
            var initiatif = await _context.Initiatifs.FindAsync(id);

            if (initiatif == null)
            {
                return NotFound();
            }

            return initiatif;
        }

        // PUT: api/Initiatifs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInitiatif(int id, Initiatif initiatif)
        {
            if (id != initiatif.InitiatifID)
            {
                return BadRequest();
            }

            _context.Entry(initiatif).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitiatifExists(id))
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

        // POST: api/Initiatifs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Initiatif>> PostInitiatif(Initiatif initiatif)
        {
            _context.Initiatifs.Add(initiatif);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInitiatif", new { id = initiatif.InitiatifID }, initiatif);
        }

        // DELETE: api/Initiatifs/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Initiatif>> DeleteInitiatif(int id)
        {
            var initiatif = await _context.Initiatifs.FindAsync(id);
            if (initiatif == null)
            {
                return NotFound();
            }

            _context.Initiatifs.Remove(initiatif);
            await _context.SaveChangesAsync();

            return initiatif;
        }

        private bool InitiatifExists(int id)
        {
            return _context.Initiatifs.Any(e => e.InitiatifID == id);
        }
    }
}
