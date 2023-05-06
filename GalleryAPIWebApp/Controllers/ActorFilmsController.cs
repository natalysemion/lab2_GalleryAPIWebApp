using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GalleryAPIWebApp.Models;

namespace GalleryAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorFilmsController : ControllerBase
    {
        private readonly GalleryAPIContext _context;

        public ActorFilmsController(GalleryAPIContext context)
        {
            _context = context;
        }

        // GET: api/ActorFilms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorFilm>>> GetActorFilms()
        {
          if (_context.ActorFilms == null)
          {
              return NotFound();
          }
            return await _context.ActorFilms.ToListAsync();
        }

        // GET: api/ActorFilms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorFilm>> GetActorFilm(int id)
        {
          if (_context.ActorFilms == null)
          {
              return NotFound();
          }
            var actorFilm = await _context.ActorFilms.FindAsync(id);

            if (actorFilm == null)
            {
                return NotFound();
            }

            return actorFilm;
        }

        // PUT: api/ActorFilms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActorFilm(int id, ActorFilm actorFilm)
        {
            if (id != actorFilm.Id)
            {
                return BadRequest();
            }

            _context.Entry(actorFilm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorFilmExists(id))
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

        // POST: api/ActorFilms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActorFilm>> PostActorFilm(ActorFilm actorFilm)
        {
          if (_context.ActorFilms == null)
          {
              return Problem("Entity set 'GalleryAPIContext.ActorFilms'  is null.");
          }
            _context.ActorFilms.Add(actorFilm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActorFilm", new { id = actorFilm.Id }, actorFilm);
        }

        // DELETE: api/ActorFilms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActorFilm(int id)
        {
            if (_context.ActorFilms == null)
            {
                return NotFound();
            }
            var actorFilm = await _context.ActorFilms.FindAsync(id);
            if (actorFilm == null)
            {
                return NotFound();
            }

            _context.ActorFilms.Remove(actorFilm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActorFilmExists(int id)
        {
            return (_context.ActorFilms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
