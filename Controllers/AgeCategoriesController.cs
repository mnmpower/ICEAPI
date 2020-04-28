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
    public class AgeCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public AgeCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AgeCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgeCategory>>> GetAgeCategories()
        {
            return await _context.AgeCategories.ToListAsync();
        }

        // GET: api/AgeCategories/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AgeCategory>> GetAgeCategory(int id)
        {
            var ageCategory = await _context.AgeCategories.FindAsync(id);

            if (ageCategory == null)
            {
                return NotFound();
            }

            return ageCategory;
        }

        // PUT: api/AgeCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgeCategory(int id, AgeCategory ageCategory)
        {
            if (id != ageCategory.AgeCategoryID)
            {
                return BadRequest();
            }

            _context.Entry(ageCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeCategoryExists(id))
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

        // POST: api/AgeCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AgeCategory>> PostAgeCategory(AgeCategory ageCategory)
        {
            _context.AgeCategories.Add(ageCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgeCategory", new { id = ageCategory.AgeCategoryID }, ageCategory);
        }

        // DELETE: api/AgeCategories/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgeCategory>> DeleteAgeCategory(int id)
        {
            var ageCategory = await _context.AgeCategories.FindAsync(id);
            if (ageCategory == null)
            {
                return NotFound();
            }

            _context.AgeCategories.Remove(ageCategory);
            await _context.SaveChangesAsync();

            return ageCategory;
        }

        private bool AgeCategoryExists(int id)
        {
            return _context.AgeCategories.Any(e => e.AgeCategoryID == id);
        }
    }
}
