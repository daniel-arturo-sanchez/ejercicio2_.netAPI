using Humanizer.Localisation;
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
        [ProducesResponseType(200)]
        public ActionResult Get()
        {
            return Ok(juegos);
        }

        // GET api/<JuegosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Get(int id)
        {
            if (id == null)
                return BadRequest();
            Juego juego = juegos.Find(x => x.Id == id);
            if (juego == null)
                return NotFound();
            return Ok(juego);
        }

        // POST api/<JuegosController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, string title, string genre)
        {
            if (id == null || title == null || genre == null)
            {
                return BadRequest("Parámetros no válidos");
            } 
            else
            {
                Juego ToUpdateGame = juegos.Find(juego => juego.Id == id);
                if (ToUpdateGame == null)
                {
                    return NotFound("No existe un juego con este índice");
                }
                else
                {
                    Juego juego = new Juego { Id = id, Title = title, Genre = genre };
                    if (TryValidateModel(juego))
                    {
                        ToUpdateGame.Title = juego.Title;
                        ToUpdateGame.Genre = juego.Genre;
                    }
                    else
                    {
                        return BadRequest("No cumples con las restricciones del modelo");
                    }
                }
                return Ok("Actualizado");
            }
        }

        // DELETE api/<JuegosController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Parámetros no válidos");
            }
            else
            {
                Juego ToUpdateGame = juegos.Find(juego => juego.Id == id);
                if (ToUpdateGame == null)
                {
                    return NotFound("No existe un juego con este índice");
                }
                else
                {
                    juegos.Remove(ToUpdateGame);
                }
                return Ok("Juego removido");
            }
        }
    }
}
