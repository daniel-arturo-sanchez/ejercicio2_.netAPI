using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        public static List<Juego> juegos = new List<Juego>{
            new Juego {
                Id = 1,
                Title = "League of Legends",
                Genre = "MOBA"
            },
            new Juego {
                Id=2,
                Title = "World of Warcraft",
                Genre = "MMORPG"
            },
            new Juego {
                Id=3,
                Title = "Pokémon Blue",
                Genre = "RPG"
            }
        };
        public static int juegoId = juegos.Count();
        // GET: api/<JuegosController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(juegos);
        }

        // GET api/<JuegosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Juego juego = juegos.Find(x => x.Id == id);
            if (juego == null)
                return NotFound();
            return Ok(juego);
        }

        // POST api/<JuegosController>
        [HttpPost]
        public void Post([FromBody] Juego juego)
        {
            juego.Id = ++juegoId;
            if (TryValidateModel(juego))
            {
                juegos.Add(juego);
                Created();
            } else
            {
                BadRequest();
            }
        }

        // PUT api/<JuegosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JuegosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
