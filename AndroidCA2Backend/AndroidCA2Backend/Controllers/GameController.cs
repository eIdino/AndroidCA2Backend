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
            new Games { Game = "CS 1.6", Genre = "FPS"},
            new Games { Game = "Elden Ring", Genre = "RPG, Action"},
            new Games { Game = "Dark Souls I", Genre = "RPG, Action"},
            new Games { Game = "Dark Souls II", Genre = "RPG, Action"},
            new Games { Game = "Dark Souls III", Genre = "RPG, Action"},
            new Games { Game = "GTA", Genre = "RPG, Action"},
            new Games { Game = "GTA II", Genre = "RPG, Action"},
            new Games { Game = "GTA III", Genre = "RPG, Action"},
            new Games { Game = "GTA San Andreas", Genre = "RPG, Action"},
            new Games { Game = "GTA IV", Genre = "RPG, Action"},
            new Games { Game = "GTA V", Genre = "RPG, Action"},
            new Games { Game = "Apex Legends", Genre = "Action, FPS"},
        };

        //GET all games in liked order
        [HttpGet]
        public IEnumerable<Games> GetAll()
        {
            return allGames.OrderByDescending(w => w.Like);
        }

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
    }
}