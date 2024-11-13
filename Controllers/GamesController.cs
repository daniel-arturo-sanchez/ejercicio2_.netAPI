using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebApi1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public GamesController()
        {

        }
        public static List<Game> games = new List<Game>{
            new Game {
                Id = 1,
                Title = "League of Legends",
                Genre = "MOBA"
            },
            new Game {
                Id=2,
                Title = "World of Warcraft",
                Genre = "MMORPG"
            },
            new Game {
                Id=3, 
                Title = "Pokémon Blue",
                Genre = "RPG"
            }
        };
        
       
        // GET: api/<GamesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<string> Get()
        {
            string result = JsonConvert.SerializeObject(games);
            return result ;
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<string> Get(int id)
        {
            string result;
            if (id == null)
                result = StatusCodes.Status406NotAcceptable.ToString();
            else
                result = JsonConvert.SerializeObject(games.Find( g => g.Id == id));
                if (result == null)
                    result = StatusCodes.Status404NotFound.ToString();
            return result;
        }

        // POST api/<GamesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(406)]
        public ActionResult<string> Post([FromQuery] string title, [FromQuery] string genre)
        {
            string result;
            if (ModelState.IsValid)
            {
                int num = games.Count;
                games.Add(new Game { Genre = genre, Title = title, Id = num + 1});
                result = StatusCodes.Status201Created.ToString();
            } else
            {
                result = StatusCodes.Status406NotAcceptable.ToString();
            }
            return result;
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<string> Put(int id, [FromBody] string title, string genre)
        {
            string result;
            if (id == null || title == null || genre == null)
                result= StatusCodes.Status406NotAcceptable.ToString();
            else 
            {
                if (ModelState.IsValid)
                {
                    Game game = games.Find(g => g.Id == id);
                    if (game == null)
                        result = StatusCodes.Status404NotFound.ToString();
                    else
                    {
                        game.Title = title;
                        game.Genre = genre;
                        result = StatusCodes.Status200OK.ToString();
                    }
                } else
                {
                    result = StatusCodes.Status406NotAcceptable.ToString();
                }
            }
            return result;
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<string> Delete(int id)
        {
            string result;
            if (id == null)
                result = StatusCodes.Status406NotAcceptable.ToString();
            else
            {
                result = JsonConvert.SerializeObject(games.Find(g => g.Id == id));
                if (result == null)
                {
                    result = StatusCodes.Status404NotFound.ToString();
                }
                else
                {
                    games.Remove(games.Find(g => g.Id == id));
                    result = StatusCodes.Status200OK.ToString();
                }

            }
            return result;
        }
    }
}
