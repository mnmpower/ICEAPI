using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICE_API.models;
using ICE_API.Services;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace ICE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private DataContext _context;
        private IAdminService _adminSerivce;

        public AdminsController(IAdminService adminSerivce, DataContext context)
        {
            _adminSerivce = adminSerivce;
            _context = context;
        }
        // GET: api/Admins/authenticate
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Admin userParam)
        {
            // hash password before compare
            var data = Encoding.ASCII.GetBytes(userParam.Password);
            var sha1 = new SHA1CryptoServiceProvider();
            userParam.Password = Convert.ToBase64String(sha1.ComputeHash(data));

            var admin = _adminSerivce.Authenticate(userParam.Email, userParam.Password);

            if (admin == null)
                return BadRequest(new { message = "Wachtwoord of username is incorrect" });

            return Ok(admin);
        }

        // GET: api/Admins/idcurrentadmin
        [Authorize]
        [HttpGet("idcurrentadmin")]
        public ActionResult<int> getIdOfCurrentAdmin()
        {
            var adminID = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "AdminID").Value);
            return Convert.ToInt32(adminID);
        }

        // GET: api/Admins
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            List<Admin> admins = await _context.Admins.ToListAsync();

            foreach (var a in admins)
            {
                a.Password = null;
            }
            return admins;
        }

        // GET: api/Admins/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            admin.Password = null;

            return admin;
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            if (id != admin.AdminID)
            {
                return BadRequest();
            }

            var data = Encoding.ASCII.GetBytes(admin.Password);
            var sha1 = new SHA1CryptoServiceProvider();
            admin.Password = Convert.ToBase64String(sha1.ComputeHash(data));

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            var data = Encoding.ASCII.GetBytes(admin.Password);
            var sha1 = new SHA1CryptoServiceProvider();
            admin.Password = Convert.ToBase64String(sha1.ComputeHash(data));

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.AdminID }, admin);
        }

        // DELETE: api/Admins/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.AdminID == id);
        }
    }
}
