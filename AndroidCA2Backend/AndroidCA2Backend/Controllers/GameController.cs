using Microsoft.AspNetCore.Mvc;

namespace AndroidCA2Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly static List<Games> allGames = new List<Games>()
        {
            new Games { Game = "CS:GO", Genre = "FPS"},
            new Games { Game = "CS:Source", Genre = "FPS"},
            new Games { Game = "CS 1.6", Genre = "FPS" },
            new Games { Game = "Elden Ring", Genre = "Adventure"},
            new Games { Game = "Dark Souls I", Genre = "RPG"},
            new Games { Game = "Dark Souls II", Genre = "RPG"},
            new Games { Game = "Dark Souls III", Genre = "RPG"},
            new Games { Game = "GTA", Genre = "Action"},
            new Games { Game = "GTA II", Genre = "Action"},
            new Games { Game = "GTA III", Genre = "Action"},
            new Games { Game = "GTA San Andreas", Genre = "Action"},
            new Games { Game = "GTA IV", Genre = "Action"},
            new Games { Game = "GTA V", Genre = "Action"},
            new Games { Game = "Apex Legends", Genre = "FPS"},
        };

        //GET all games in liked order
        [HttpGet]
        public IEnumerable<Games> GetAll()
        {
            return allGames.OrderByDescending(w => w.Like);
        }

        //PUT for likes
        [HttpPut("game/{game}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PutLikeGame([FromRoute] string game)
        {
            var like = allGames.SingleOrDefault(r => r.Game == game);
            if (like == null)
            {
                return NotFound();
            }
            else
            {
                like.Like++;
                return NoContent();
            }
        }

        //GET search/{game}
        [HttpGet("search/{game}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Games> GetGame(string game)
        {
            // LINQ query search by game name
            var searchG = allGames.FirstOrDefault(p => p.Game.ToLower() == game.ToLower());
            if (searchG == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(searchG);
            }
        }

        //GET search/genre/{genre}
        [HttpGet("search/genre/{genre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Games> GetGenre(string genre)
        {
            // LINQ query search by genre
            var searchG = allGames.Where(p => p.Genre.ToLower() == genre.ToLower());
            if (searchG == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(searchG);
            }
        }

    }
}