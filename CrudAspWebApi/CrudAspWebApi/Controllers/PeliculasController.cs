using CrudAspWebApi.Data;
using CrudAspWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly AplicationDbContext _db;
        public PeliculasController(AplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(List<Pelicula>))]//indicamos de que tipo sera el objeto que retorne
        [ProducesResponseType(400)]//bad request
        public async Task<IActionResult> getPeliculas()
        {
            var peliculas =await _db.peliculas.OrderBy(peliculas => peliculas.nombre)//orderBy ordena en este caso por nombre
                .Include(peliculas=>peliculas.Categoria).ToListAsync();//el include es para traer los datos de la tabla relacionado por el id
            return Ok(peliculas);
        }

        [HttpGet("{id:int}", Name = "getPelicula")]
        [ProducesResponseType(200, Type = typeof(Pelicula))]//indicamos de que tipo sera el objeto que retorne
        [ProducesResponseType(400)]
        public async Task<IActionResult> getPelicula(int? id)
        {
            var pelicula = await _db.peliculas.Include(peliculaId => peliculaId.Categoria)
                .FirstOrDefaultAsync(peliculaID => peliculaID.Id==id);//Devuelve de forma asincrónica el primer elemento de una secuencia, o un valor predeterminado si la secuencia no contiene elementos. 

            if (pelicula==null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]//error interno
        public async Task<IActionResult> crearPelicula([FromBody]Pelicula pelicula)
        {
            if (pelicula==null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

               await _db.AddAsync(pelicula);
               await _db.SaveChangesAsync();

            return CreatedAtRoute("getPelicula", new { id=pelicula.Id }, pelicula);//le mandamos el id del obejto que acabamos de crear para que muestre en el resultado
        }
    }
}
