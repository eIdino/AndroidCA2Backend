#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndroidCA2Backend;
using AndroidCA2Backend.Data;

namespace AndroidCA2Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AndroidCA2BackendContext _context;

        public GamesController(AndroidCA2BackendContext context)
        {
            _context = context;
        }

        //GET all by api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Games>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        //GET by id api/Games/find/14
        [HttpGet("find/{id}")]
        public async Task<ActionResult<Games>> GetGames(int id)
        {
            var games = await _context.Games.FindAsync(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        //GET by genre api/Games/genre/action
        [HttpGet("genre/{genre}")]
        public IEnumerable<Games> GetGamesByGenre(string genre)
        {
            var games = _context.Games.Where(g => g.Genre == genre);

            if (games == null)
            {
                return null;
            }

            return games;
        }

        //PUT by id api/Games/update/14 takes in json
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutGames(int id, Games games)
        {
            if (id != games.Id)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
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

        //POST new to db api/Games takes in json
        [HttpPost]
        public async Task<ActionResult<Games>> PostGames(Games games)
        {
            _context.Games.Add(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGames", new { id = games.Id }, games);
        }

        //DELETE by id api/Games/del/14
        [HttpDelete("del/{id}")]
        public async Task<IActionResult> DeleteGames(int id)
        {
            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            _context.Games.Remove(games);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }

        //GET by genre api/Games/game/APB Reloaded
        [HttpGet("game/{game}")]
        public IEnumerable<Games> GetGamesByName(string game)
        {
            var games = _context.Games.Where(g => g.Game == game);

            if (games == null)
            {
                return null;
            }

            return games;
        }

        //PUT by genre api/Games/like/APB Reloaded
        [HttpPut("like/{game}")]
        public async Task<IActionResult> PutLike(string game)
        {
            Games games = _context.Games.FirstOrDefault(g => g.Game == game);

            if (games == null) 
            { 
                return NotFound(); 
            }

            else
            {
                games.Like++;
                _context.SaveChanges();
            }
            return NoContent();
        }
    }
}
