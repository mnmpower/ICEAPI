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
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/whereShowIsTrue
        [HttpGet("whereShowIsTrue")]
        public async Task<ActionResult<IEnumerable<Project>>> getProjectsWhereShowIsTrue()
        {
            return await _context.Projects
                .Where(p => p.Show == true)
                .Include(p => p.AgeCategory)
                .Include(p => p.Duration)
                .ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectID }, project);
        }

        // POST: api/Projects/zoek
        [HttpPost("zoek")]
        public async Task<ActionResult<IEnumerable<Project>>> ZoekProjecten(ZoekProject zp)
        {
            List<Project> projecten = new List<Project>();
            projecten = await _context.Projects.Where(p => p.Show == true)
                .Include(p => p.AgeCategory)
                .Include(p => p.Duration)
                .ToListAsync();

            if (zp.CategoryID != 0)
            {
                projecten = projecten.Where(p => p.CategoryID == zp.CategoryID).ToList(); ;
            }

            if (zp.PersonID != 0)
            {
                projecten = projecten.Where(p => p.PersonID == zp.PersonID).ToList(); ;
            }

            if (zp.AgeCategoryID != 0)
            {
                projecten = projecten.Where(p => p.AgeCategoryID == zp.AgeCategoryID).ToList(); ;
            }

            if (zp.DurationID != 0)
            {
                projecten = projecten.Where(p => p.DurationID == zp.DurationID).ToList(); ;
            }


            return projecten;

        }

        // DELETE: api/Projects/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}
