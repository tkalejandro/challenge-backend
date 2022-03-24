#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using authapp_react_net.Models;

namespace authapp_react_net.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserSchemasController : ControllerBase
    {
        private readonly UserSchemaContext _context;

        public UserSchemasController(UserSchemaContext context)
        {
            _context = context;
        }

        // GET: api/UserSchemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSchema>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserSchemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSchema>> GetUserSchema(long id)
        {
            var userSchema = await _context.Users.FindAsync(id);

            if (userSchema == null)
            {
                return NotFound();
            }

            return userSchema;
        }

        // PUT: api/UserSchemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSchema(long id, UserSchema userSchema)
        {
            if (id != userSchema.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSchemaExists(id))
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

        // POST: api/UserSchemas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<UserSchema>> PostUserSchema(UserSchema userSchema)
        {
            _context.Users.Add(userSchema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSchema", new { id = userSchema.Id }, userSchema);
        }

        // DELETE: api/UserSchemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSchema(long id)
        {
            var userSchema = await _context.Users.FindAsync(id);
            if (userSchema == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userSchema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSchemaExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
