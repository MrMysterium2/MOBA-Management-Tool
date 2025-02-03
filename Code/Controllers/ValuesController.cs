using Microsoft.AspNetCore.Mvc;
using Code.DTOs;
using System.Collections.Generic;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // static list to hold the players in memory (for testing) (for testing) (for testing) (for testing) (for testing) (for testing) (for testing)
        private static List<PlayerCreateDto> players = new List<PlayerCreateDto>();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost("player")]
        public ActionResult<PlayerCreateDto> CreatePlayer([FromBody] PlayerCreateDto player)
        {
            if (player == null)
            {
                return BadRequest("Player data is required");
            }

            if (string.IsNullOrWhiteSpace(player.Name) || string.IsNullOrWhiteSpace(player.Email) || string.IsNullOrWhiteSpace(player.FirstName) || string.IsNullOrWhiteSpace(player.LastName))
            {
                return BadRequest("Every field is required");
            }

            // save this to the actual database (for testing) (for testing) (for testing) (for testing) (for testing) (for testing) (for testing)
            players.Add(player);

            // return the id of the player when database exists
            return CreatedAtAction(nameof(Get), new { id = players.Count - 1 }, player);
        }
    }
}
